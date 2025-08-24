using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ClinicalNotesSummarization.Orchestration.Services;
using ClinicalNotesSummarization.Application.Features.AI;
using ClinicalNotesSummarization.Orchestration.Plugins;

namespace ClinicalNotesSummarization.Orchestration;

public static class RegistrationExtensions
{
    public static IServiceCollection AddOrchestrationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Register OpenAI settings read from configuration
        var openAiSettings = CreateOpenAiSettings(configuration);
        services.AddSingleton(openAiSettings);
        services.AddTransient<IPatientPlugin, PatientRepositoryPlugin>();
        services.AddSingleton(KernelFactory.CreateKernel(openAiSettings));
        services.AddTransient<ITextGenerator, DefaultTextGenerator>();

        // // Register orchestration implementations for application interfaces
        services.AddScoped<ISummarizationService, SemanticSummarizationService>();
        services.AddScoped<IPatientChatService, PatientChatService>();

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
