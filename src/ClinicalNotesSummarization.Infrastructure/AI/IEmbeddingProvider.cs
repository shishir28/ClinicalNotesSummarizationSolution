using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicalNotesSummarization.Infrastructure.AI
{
    /// <summary>
    /// Abstraction over embedding provider (OpenAI, local, etc.). Returns a float[] embedding for each input text.
    /// </summary>
    public interface IEmbeddingProvider
    {
        Task<IEnumerable<float[]>> GetEmbeddingsAsync(IEnumerable<string> inputs);
    }
}
