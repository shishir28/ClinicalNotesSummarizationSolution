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

            services.AddHttpClient<IPatientService, PatientService>(c => c.BaseAddress = new Uri(configuration["ApiSettings:GatewayAddress"]));
            services.AddHttpClient<IMedicationService, MedicationService>(c => c.BaseAddress = new Uri(configuration["ApiSettings:GatewayAddress"]));

            services.AddScoped<INotificationService, NotificationService>();
            return services;
        }
    }
}
