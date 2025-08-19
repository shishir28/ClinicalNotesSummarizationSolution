using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace ClinicalNotesSummarization.Orchestration.Services;

public interface ITextGenerator
{
    Task<string> GenerateAsync(string prompt, CancellationToken cancellationToken = default);
}

public class DefaultTextGenerator : ITextGenerator
{
    private readonly OpenAiSettings _settings;
    private readonly Kernel _kernel;

    public DefaultTextGenerator(OpenAiSettings settings, Kernel kernel)
    {
        _settings = settings;
        _kernel = kernel;
    }

    public async Task<string> GenerateAsync(string prompt, CancellationToken cancellationToken = default)
    {
        try
        {
            var requestSettings = new OpenAIPromptExecutionSettings
            {
                MaxTokens = 1024,
                Temperature = 0.2
            };

            var kernelArgs = new KernelArguments
            {
                { "executionSettings", requestSettings }
            };

            var result = await _kernel.InvokePromptAsync(prompt, kernelArgs, cancellationToken: cancellationToken);

            var openAiChat = result.GetValue<OpenAIChatMessageContent>();
            if (openAiChat != null)
                return StripFencesAndLeadingLabel(openAiChat.Content);

            return result?.ToString() ?? string.Empty;
        }
        catch (Exception ex)
        {
            // Fallback: return a deterministic simulated response to avoid breaking callers
            return $"[SIMULATED RESPONSE due to error: {ex.Message}] Summary for prompt: {prompt.Substring(0, Math.Min(200, prompt.Length))}";
        }
    }

    private static string StripFencesAndLeadingLabel(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return s ?? string.Empty;
        s = s.Trim();
        if (s.StartsWith("```"))
        {
            var firstNewline = s.IndexOf('\n');
            if (firstNewline >= 0) s = s.Substring(firstNewline + 1).Trim();
            if (s.EndsWith("```")) s = s.Substring(0, s.Length - 3).Trim();
        }
        // remove leading "json" label if present
        if (s.StartsWith("json", StringComparison.OrdinalIgnoreCase))
        {
            var idx = s.IndexOf('{');
            if (idx >= 0) s = s[idx..].Trim();
        }
        return s;
    }
}
