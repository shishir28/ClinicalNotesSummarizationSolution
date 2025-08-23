using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace ClinicalNotesSummarization.Infrastructure.Tools
{
    internal class QdrantIntegrationRunner
    {
        public static async Task<int> Main(string[] args)
        {
            // Use defaults for the integration runner to avoid extra configuration dependencies.
            var url = Environment.GetEnvironmentVariable("QDRANT_URL") ?? "http://localhost:6333";
            var http = new System.Net.Http.HttpClient { BaseAddress = new Uri(url) };
            var store = new AI.QdrantVectorStore(url, 1536, http);
            await store.EnsureCollectionAsync();

            var pointId = "integration:sample:0";
            var vector = new float[1536];
            vector[0] = 0.123f;
            var payload = new System.Collections.Generic.Dictionary<string, object?> { { "patient_id", "test-patient" }, { "source_table", "ClinicalNotes" } };
            var tupleList = new (string PointId, float[] Vector, System.Collections.Generic.IReadOnlyDictionary<string, object?> Payload)[] { (pointId, vector, payload) };
            await store.UpsertPointsAsync(tupleList);

            var results = await store.SearchAsync(vector, topK: 5);
            Console.WriteLine($"Found {System.Linq.Enumerable.Count(results)} results");
            foreach (var r in results)
                Console.WriteLine($"{r.PointId} score={r.Score}");

            return 0;
        }
    }
}
