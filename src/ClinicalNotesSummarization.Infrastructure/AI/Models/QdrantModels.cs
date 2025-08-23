using System;
using System.Collections.Generic;
using System.Globalization;

namespace ClinicalNotesSummarization.Infrastructure.AI.Models
{
    /// <summary>
    /// Strongly-typed payload stored alongside vectors in Qdrant.
    /// Keys match payload names used when upserting/searching points.
    /// </summary>
    public record QdrantPayload
    {
        public string EntityType { get; init; } = string.Empty;
        public Guid EntityId { get; init; }
        public Guid PatientId { get; init; }
        public string FieldSource { get; init; } = string.Empty;
        public int ChunkIndex { get; init; }
        public string TextHash { get; init; } = string.Empty;
        public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.UtcNow;
        public string? SourceSnippet { get; init; }
        public string? Language { get; init; }
        public int? OriginalLength { get; init; }
        public IReadOnlyDictionary<string, object?>? Extra { get; init; }

        public IReadOnlyDictionary<string, object?> ToDictionary()
        {
            var d = new Dictionary<string, object?>
            {
                ["entityType"] = EntityType,
                ["entityId"] = EntityId.ToString(),
                ["patientId"] = PatientId.ToString(),
                ["fieldSource"] = FieldSource,
                ["chunkIndex"] = ChunkIndex,
                ["textHash"] = TextHash,
                ["createdAt"] = CreatedAt.ToString("o", CultureInfo.InvariantCulture),
                ["sourceSnippet"] = SourceSnippet,
                ["language"] = Language,
                ["originalLength"] = OriginalLength
            };

            if (Extra is not null)
            {
                // store extras under an 'extra' key to avoid collisions
                d["extra"] = Extra;
            }

            return d;
        }

        public static QdrantPayload? FromDictionary(IReadOnlyDictionary<string, object?>? dict)
        {
            if (dict is null) return null;

            static Guid ParseGuid(object? v)
            {
                if (v is Guid g) return g;
                if (v is string s && Guid.TryParse(s, out var parsed)) return parsed;
                return Guid.Empty;
            }

            static int ParseInt(object? v)
            {
                if (v is int i) return i;
                if (v is long l) return (int)l;
                if (v is double d) return (int)d;
                if (v is string s && int.TryParse(s, out var parsed)) return parsed;
                return 0;
            }

            var payload = new QdrantPayload
            {
                EntityType = dict.TryGetValue("entityType", out var et) ? et?.ToString() ?? string.Empty : string.Empty,
                EntityId = ParseGuid(dict.TryGetValue("entityId", out var eid) ? eid : null),
                PatientId = ParseGuid(dict.TryGetValue("patientId", out var pid) ? pid : null),
                FieldSource = dict.TryGetValue("fieldSource", out var fs) ? fs?.ToString() ?? string.Empty : string.Empty,
                ChunkIndex = dict.TryGetValue("chunkIndex", out var ci) ? ParseInt(ci) : 0,
                TextHash = dict.TryGetValue("textHash", out var th) ? th?.ToString() ?? string.Empty : string.Empty,
                CreatedAt = dict.TryGetValue("createdAt", out var ca) && ca is string cas && DateTimeOffset.TryParse(cas, null, DateTimeStyles.RoundtripKind, out var dto) ? dto : DateTimeOffset.MinValue,
                SourceSnippet = dict.TryGetValue("sourceSnippet", out var ss) ? ss?.ToString() : null,
                Language = dict.TryGetValue("language", out var lg) ? lg?.ToString() : null,
                OriginalLength = dict.TryGetValue("originalLength", out var ol) ? (ol is null ? null : (int?)ParseInt(ol)) : null
            };

            if (dict.TryGetValue("extra", out var extraObj) && extraObj is IReadOnlyDictionary<string, object?> extraDict)
            {
                payload = payload with { Extra = extraDict };
            }
            else if (dict.TryGetValue("extra", out extraObj) && extraObj is IDictionary<string, object?> ed)
            {
                payload = payload with { Extra = new Dictionary<string, object?>(ed) };
            }

            return payload;
        }
    }

    /// <summary>
    /// Represents a point to be upserted into Qdrant (id, vector and typed payload).
    /// </summary>
    public record QdrantPoint(string PointId, float[] Vector, QdrantPayload Payload)
    {
        public (string PointId, float[] Vector, IReadOnlyDictionary<string, object?> PayloadDict) ToUpsertTuple()
            => (PointId, Vector, Payload.ToDictionary());

        public static QdrantPoint? FromSearchResult(string pointId, IReadOnlyDictionary<string, object?>? payloadDict, float[] vector)
        {
            var payload = QdrantPayload.FromDictionary(payloadDict);
            if (payload is null) return null;
            return new QdrantPoint(pointId, vector, payload);
        }
    }
}
