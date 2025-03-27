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
            return services;
        }
    }
}
