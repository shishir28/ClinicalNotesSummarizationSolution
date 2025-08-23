using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicalNotesSummarization.Infrastructure.AI.Models;

namespace ClinicalNotesSummarization.Infrastructure.AI
{
    public record QdrantSearchResult(string PointId, float Score, IReadOnlyDictionary<string, object?> Payload);

    public interface IQdrantVectorStore
    {
        Task EnsureCollectionAsync();
        Task UpsertPointsAsync(IEnumerable<(string PointId, float[] Vector, IReadOnlyDictionary<string, object?> Payload)> points);
        // Strongly-typed overloads using Qdrant models
        Task UpsertPointsAsync(IEnumerable<QdrantPoint> points);
        Task<IEnumerable<QdrantSearchResult>> SearchAsync(float[] vector, int topK = 100, int ef = 128);
        Task<IEnumerable<QdrantPoint>> SearchPointsAsync(float[] vector, int topK = 100, int ef = 128);
        Task DeletePointsAsync(IEnumerable<string> pointIds);
    }
}
