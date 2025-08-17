using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ClinicalNotesSummarization.Orchestration.Services;
using ClinicalNotesSummarization.Application.Features.AI;

namespace ClinicalNotesSummarization.Orchestration;

public static class RegistrationExtensions
{
    public static IServiceCollection AddOrchestrationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Register OpenAI settings read from configuration
        var openAiSettings = CreateOpenAiSettings(configuration);
        services.AddSingleton(openAiSettings);
        services.AddSingleton(KernelFactory.CreateKernel(openAiSettings));

        // // Register orchestration implementations for application interfaces
        services.AddScoped<ISummarizationService, SemanticSummarizationService>();

        return services;
    }

    private static OpenAiSettings CreateOpenAiSettings(IConfiguration configuration)
    {
        return new OpenAiSettings
        {
            ApiKey = configuration["OpenAiSettings:apiKey"] ?? Environment.GetEnvironmentVariable("OPENAI_API_KEY"),
            //Endpoint = configuration["OpenAI:Endpoint"],
            OpenAiModelName = configuration["OpenAiSettings:openAiModelName"],
            EmbeddingsModelName = configuration["OpenAiSettings:openAiModelName"]
        };
    }
}
