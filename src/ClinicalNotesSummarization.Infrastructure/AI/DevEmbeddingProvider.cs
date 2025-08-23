using System.Security.Cryptography;
using System.Text;
using ClinicalNotesSummarization.Infrastructure.AI;
using Microsoft.Extensions.Configuration;

namespace ClinicalNotesSummarization.Infrastructure.AI
{
    /// <summary>
    /// Development embedding provider that produces deterministic pseudo-embeddings from text.
    /// Uses a configuration key `Qdrant:VectorSize` to determine vector length (default 1536).
    /// This is suitable for local development and testing only.
    /// </summary>
    public class DevEmbeddingProvider : IEmbeddingProvider
    {
        private readonly int _vectorSize;

        public DevEmbeddingProvider(IConfiguration configuration)
        {
            if (!int.TryParse(configuration["Qdrant:VectorSize"], out _vectorSize))
            {
                _vectorSize = 1536; // reasonable default for many embedding models
            }
        }

        public Task<IEnumerable<float[]>> GetEmbeddingsAsync(IEnumerable<string> inputs)
        {
            var results = new List<float[]>();

            foreach (var input in inputs)
            {
                // Create a deterministic seed from the SHA256 of the input
                var hash = SHA256.HashData(Encoding.UTF8.GetBytes(input ?? string.Empty));
                // Use first 8 bytes as a seed
                long seed = 0;
                for (int i = 0; i < Math.Min(8, hash.Length); i++)
                {
                    seed = (seed << 8) | hash[i];
                }

                var rnd = new Random((int)(seed & 0x7FFFFFFF));
                var vec = new float[_vectorSize];
                for (int i = 0; i < _vectorSize; i++)
                {
                    // Generate values in range [-1,1]
                    vec[i] = (float)((rnd.NextDouble() * 2.0) - 1.0);
                }

                results.Add(vec);
            }

            return Task.FromResult((IEnumerable<float[]>)results);
        }
    }
}
