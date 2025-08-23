using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ClinicalNotesSummarization.Infrastructure.AI.Models;

namespace ClinicalNotesSummarization.Infrastructure.AI
{
    public class QdrantVectorStore : IQdrantVectorStore
    {
        private readonly HttpClient _http;
        private readonly string _collectionName;
        private readonly int _vectorSize;

        public QdrantVectorStore(Microsoft.Extensions.Configuration.IConfiguration configuration, HttpClient httpClient)
        {
            var url = configuration["Qdrant:Url"] ?? "http://localhost:6333";
            _collectionName = configuration["Qdrant:CollectionName"] ?? "patient_embeddings";
            if (!int.TryParse(configuration["Qdrant:VectorSize"], out var vecSize))
                vecSize = 1536;
            _vectorSize = vecSize;
            _http = httpClient;
            if (_http.BaseAddress == null)
                _http.BaseAddress = new Uri(url);
        }

        // Simple overload for direct construction
        public QdrantVectorStore(string baseUrl, int vectorSize, HttpClient httpClient)
        {
            _collectionName = "patient_embeddings";
            _vectorSize = vectorSize;
            _http = httpClient;
            if (_http.BaseAddress == null)
                _http.BaseAddress = new Uri(baseUrl);
        }

        public async Task EnsureCollectionAsync()
        {
            var res = await _http.GetAsync($"/collections");
            res.EnsureSuccessStatusCode();
            using var doc = await JsonDocument.ParseAsync(await res.Content.ReadAsStreamAsync());
            var exists = false;
            if (doc.RootElement.TryGetProperty("result", out var result) && result.ValueKind == JsonValueKind.Object && result.TryGetProperty("collections", out var collections))
            {
                foreach (var c in collections.EnumerateArray())
                {
                    if (c.GetProperty("name").GetString() == _collectionName)
                    {
                        exists = true; break;
                    }
                }
            }

            if (!exists)
            {
                var payload = new
                {
                    vectors = new { size = _vectorSize, distance = "Cosine" },
                    // hnsw_config and other options can be added here
                };
                var create = await _http.PutAsJsonAsync($"/collections/{_collectionName}", payload);
                create.EnsureSuccessStatusCode();
            }
        }

        public async Task UpsertPointsAsync(IEnumerable<(string PointId, float[] Vector, IReadOnlyDictionary<string, object?> Payload)> points)
        {
            var pts = points.Select(p => new
            {
                // Qdrant accepts numeric ids or UUIDs. Convert non-UUID string ids into deterministic UUIDs.
                id = IsValidUuid(p.PointId) ? p.PointId : CreateDeterministicUuid(p.PointId),
                vector = p.Vector?.Select(v => (double)v).ToArray() ?? Array.Empty<double>(),
                payload = p.Payload
            }).ToArray();

            // sanity-check vectors
            foreach (var pt in pts)
            {
                if (pt.vector.Length != _vectorSize)
                    throw new InvalidOperationException($"Point '{pt.id}' vector length {pt.vector.Length} does not match configured vector size {_vectorSize}.");
            }

            var body = new { points = pts };
            var res = await _http.PutAsJsonAsync($"/collections/{_collectionName}/points?wait=true", body);
            if (!res.IsSuccessStatusCode)
            {
                var text = await res.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Qdrant upsert failed {(int)res.StatusCode} {res.ReasonPhrase}: {text}");
            }
        }

        private static bool IsValidUuid(string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            return Guid.TryParse(s, out _);
        }

        private static string CreateDeterministicUuid(string? input)
        {
            // Use MD5 to create a deterministic 16-byte value and construct a GUID from it.
            // This is not a RFC v5 UUID but produces a stable UUID-like identifier for Qdrant.
            input ??= string.Empty;
            using var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            var guid = new Guid(hash);
            return guid.ToString();
        }

        // Convenience overload: accept strongly-typed QdrantPoint instances
        public Task UpsertPointsAsync(IEnumerable<QdrantPoint> points)
        {
            var tuples = points.Select(p => p.ToUpsertTuple());
            return UpsertPointsAsync(tuples);
        }

        public async Task<IEnumerable<QdrantSearchResult>> SearchAsync(float[] vector, int topK = 100, int ef = 128)
        {
            var body = new { vector = vector.Select(v => (double)v).ToArray(), limit = topK, with_payload = true };
            var res = await _http.PostAsJsonAsync($"/collections/{_collectionName}/points/search", body);
            res.EnsureSuccessStatusCode();
            using var doc = await JsonDocument.ParseAsync(await res.Content.ReadAsStreamAsync());
            var list = new List<QdrantSearchResult>();
            if (doc.RootElement.TryGetProperty("result", out var result) && result.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in result.EnumerateArray())
                {
                    var id = item.GetProperty("id").GetString() ?? string.Empty;
                    var score = item.GetProperty("score").GetSingle();
                    var payload = new Dictionary<string, object?>();
                    if (item.TryGetProperty("payload", out var pl) && pl.ValueKind == JsonValueKind.Object)
                    {
                        foreach (var prop in pl.EnumerateObject())
                        {
                            payload[prop.Name] = prop.Value.ValueKind switch
                            {
                                JsonValueKind.String => prop.Value.GetString(),
                                JsonValueKind.Number => prop.Value.GetDouble(),
                                JsonValueKind.True => true,
                                JsonValueKind.False => false,
                                _ => prop.Value.ToString()
                            };
                        }
                    }

                    list.Add(new QdrantSearchResult(id, score, payload));
                }
            }

            return list;
        }

        // New: typed search that returns QdrantPoint including vectors and parsed payload
        public async Task<IEnumerable<QdrantPoint>> SearchPointsAsync(float[] vector, int topK = 100, int ef = 128)
        {
            var body = new { vector = vector.Select(v => (double)v).ToArray(), limit = topK, with_payload = true, with_vector = true };
            var res = await _http.PostAsJsonAsync($"/collections/{_collectionName}/points/search", body);
            res.EnsureSuccessStatusCode();
            using var doc = await JsonDocument.ParseAsync(await res.Content.ReadAsStreamAsync());
            var list = new List<QdrantPoint>();
            if (doc.RootElement.TryGetProperty("result", out var result) && result.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in result.EnumerateArray())
                {
                    var id = item.GetProperty("id").GetString() ?? string.Empty;

                    // parse vector if present
                    float[] vectorArr = Array.Empty<float>();
                    if (item.TryGetProperty("vector", out var vecEl) && vecEl.ValueKind == JsonValueKind.Array)
                    {
                        var tmp = new List<float>();
                        foreach (var v in vecEl.EnumerateArray())
                        {
                            if (v.TryGetDouble(out var dv)) tmp.Add((float)dv);
                        }
                        vectorArr = tmp.ToArray();
                    }

                    // parse payload
                    Dictionary<string, object?> payload = new();
                    if (item.TryGetProperty("payload", out var pl) && pl.ValueKind == JsonValueKind.Object)
                    {
                        foreach (var prop in pl.EnumerateObject())
                        {
                            payload[prop.Name] = prop.Value.ValueKind switch
                            {
                                JsonValueKind.String => prop.Value.GetString(),
                                JsonValueKind.Number => prop.Value.GetDouble(),
                                JsonValueKind.True => true,
                                JsonValueKind.False => false,
                                _ => prop.Value.ToString()
                            };
                        }
                    }

                    var parsed = QdrantPayload.FromDictionary(payload);
                    if (parsed is not null)
                    {
                        list.Add(new QdrantPoint(id, vectorArr, parsed));
                    }
                }
            }

            return list;
        }

        public async Task DeletePointsAsync(IEnumerable<string> pointIds)
        {
            var body = new { ids = pointIds.ToArray() };
            var res = await _http.PostAsJsonAsync($"/collections/{_collectionName}/points/delete?wait=true", body);
            res.EnsureSuccessStatusCode();
        }
    }
}
