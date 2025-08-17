namespace ClinicalNotesSummarization.Orchestration;

public class OpenAiSettings
{
    /// <summary>
    /// Api key for OpenAI / Azure OpenAI. Can also be provided via environment variables or the "OpenAI:ApiKey" configuration section.
    /// </summary>
    public string? ApiKey { get; set; }

    /// <summary>
    /// Optional endpoint for Azure OpenAI (e.g. https://myresource.openai.azure.com/).
    /// </summary>
    public string? Endpoint { get; set; }

    /// <summary>
    /// Default model name to use for completions (from OpenAiSettings:openAiModelName in appsettings.json).
    /// </summary>
    public string? OpenAiModelName { get; set; }

    /// <summary>
    /// Default embeddings model name (from OpenAiSettings:embeddingsModelName in appsettings.json).
    /// </summary>
    public string? EmbeddingsModelName { get; set; }
}
