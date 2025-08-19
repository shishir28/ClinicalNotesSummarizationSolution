using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using OpenTelemetry.Logs;

namespace ClinicalNotesSummarization.Orchestration;

public static class KernelFactory
{
    public static Kernel CreateKernel(OpenAiSettings openAiSettings)
    {
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddOpenTelemetry(options =>
            {
                //options.SetResourceBuilder(resourceBuilder);
                options.AddConsoleExporter();
                options.IncludeFormattedMessage = true;
                options.IncludeScopes = true;
            });
            builder.SetMinimumLevel(LogLevel.Information);
        });

        var builder = Kernel.CreateBuilder();

        if (string.IsNullOrEmpty(openAiSettings.OpenAiModelName))
        {
            throw new ArgumentNullException(nameof(openAiSettings.OpenAiModelName), "OpenAI model name cannot be null or empty.");
        }
        

        builder.AddOpenAIChatCompletion(
            openAiSettings.OpenAiModelName,
            openAiSettings.ApiKey);

        return builder.Build();
    }
}
