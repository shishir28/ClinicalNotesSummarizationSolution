namespace ClinicalNotesSummarization.Orchestration.Services;

public interface ITextGenerator
{
    Task<string> GenerateAsync(string prompt, CancellationToken cancellationToken = default);
}

public class DefaultTextGenerator : ITextGenerator
{
    private readonly OpenAiSettings _settings;

    public DefaultTextGenerator(OpenAiSettings settings)
    {
        _settings = settings;
    }

    public Task<string> GenerateAsync(string prompt, CancellationToken cancellationToken = default)
    {
        // Placeholder: actual implementation should call Semantic Kernel or direct OpenAI/Azure SDKs
        return Task.FromResult($"[SIMULATED RESPONSE based on model {_settings.OpenAiModelName}] Summary for prompt: {prompt.Substring(0, Math.Min(200, prompt.Length))}");
    }
}
