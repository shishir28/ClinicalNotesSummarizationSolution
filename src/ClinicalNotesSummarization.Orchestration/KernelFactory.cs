using Microsoft.Extensions.Configuration;
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

        var builder = Kernel.CreateBuilder(); ;

        //var oenAiKey = configuration["OpenAI:ApiKey"];
        //var openAiEndpoint = configuration["OpenAI:Endpoint"]; // For Azure OpenAI this will be set

        //if (!string.IsNullOrEmpty(openAiEndpoint))
        //{
        //    var client = new AzureOpenAIClientOptions
        //    {
        //        ApiKey = openAiKey,
        //        Endpoint = openAiEndpoint
        //    };
        //    builder.WithAzureOpenAITextCompletionService("azure-openai", client);
        //}
        //else
        //{
        //    var client = new OpenAITextCompletionServiceOptions
        //    {
        //        ApiKey = openAiKey,
        //    };
        //    builder.WithOpenAITextCompletionService("openai", client);
        //}

        return builder.Build();
    }
}
