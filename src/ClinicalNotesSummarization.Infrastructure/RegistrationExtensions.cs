using ClinicalNotesSummarization.Domain.Repositories;
using ClinicalNotesSummarization.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicalNotesSummarization.Infrastructure
{
    public static class RegistrationExtensions
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IMedicationRepository, MedicationRepository>();
            services.AddScoped<IAllergyRepository, AllergyRepository>();
            services.AddScoped<IDiagnosisRepository, DiagnosisRepository>();
            services.AddScoped<IMedicalConditionRepository, MedicalConditionRepository>();
            // Qdrant vector store - register via factory so we can provide HttpClient from configuration
            services.AddSingleton<AI.IQdrantVectorStore>(sp =>
            {
                var cfg = sp.GetRequiredService<Microsoft.Extensions.Configuration.IConfiguration>();
                var url = cfg["Qdrant:Url"] ?? "http://localhost:6333";
                var http = new System.Net.Http.HttpClient { BaseAddress = new System.Uri(url) };
                return new AI.QdrantVectorStore(cfg, http);
            });
            // Development embedding provider (deterministic pseudo-embeddings). Replace with a real provider in production.
            services.AddScoped<AI.IEmbeddingProvider, AI.DevEmbeddingProvider>();
            return services;
        }
    }
}
