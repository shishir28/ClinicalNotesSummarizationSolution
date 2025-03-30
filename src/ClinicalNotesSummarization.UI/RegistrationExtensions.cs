using ClinicalNotesSummarization.UI.Services;

namespace ClinicalNotesSummarization.UI
{
    public static class RegistrationExtensions
    {
        public static IServiceCollection AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
            var baseAddress = new Uri(configuration["ApiSettings:GatewayAddress"]);

            services.AddHttpClient<IPatientService, PatientService>(c => c.BaseAddress = baseAddress);
            services.AddHttpClient<IMedicationService, MedicationService>(c => c.BaseAddress = baseAddress);
            services.AddHttpClient<IAllergyService, AllergyService>(c => c.BaseAddress = baseAddress);
            services.AddHttpClient<IDiagnosisService, DiagnosisService>(c => c.BaseAddress = baseAddress);
            services.AddHttpClient<IMedicalConditionService, MedicalConditionService>(c => c.BaseAddress = baseAddress);

            services.AddScoped<INotificationService, NotificationService>();
            return services;
        }
    }
}
