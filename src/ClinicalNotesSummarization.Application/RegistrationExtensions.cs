using Microsoft.Extensions.DependencyInjection;
using ClinicalNotesSummarization.Application.Features.Patients.Commands;
using ClinicalNotesSummarization.Application.Mappings;

namespace ClinicalNotesSummarization.Application
{
    public static class RegistrationExtensions
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<PatientCommandHandler>());
            return services;
        }
    }
}
