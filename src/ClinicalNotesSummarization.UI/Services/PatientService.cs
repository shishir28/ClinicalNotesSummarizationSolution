using ClinicalNotesSummarization.UI.Models;

namespace ClinicalNotesSummarization.UI.Services
{
    public interface IPatientService
    {
        Task<List<PatientDto>> GetPatients();
        Task<PatientDto> GetPatientById(Guid id);
        Task AddPatient(PatientDto patient);
        Task UpdatePatient(PatientDto patient);
        Task DeletePatient(Guid id);

        Task<List<MedicationDto>> GetMedicationsByPatientId(Guid patientId);
        Task<List<AllergyDto>> GeAllergiesByPatientId(Guid patientId);
    }

    public class PatientService : IPatientService
    {
        private readonly HttpClient _httpClient;

        public PatientService(HttpClient httpClient)  {
            _httpClient = httpClient!;
        }

        public async Task<List<PatientDto>> GetPatients() =>
          await _httpClient.GetFromJsonAsync<List<PatientDto>>("api/patients");

        public async Task<PatientDto> GetPatientById(Guid id) =>
            await _httpClient.GetFromJsonAsync<PatientDto>($"api/patients/{id}");

        public async Task AddPatient(PatientDto patient) =>
            await _httpClient.PostAsJsonAsync("api/patients", patient);

        public async Task UpdatePatient(PatientDto patient) =>
            await _httpClient.PutAsJsonAsync($"api/patients/{patient.Id}", patient);

        public async Task DeletePatient(Guid id) =>
            await _httpClient.DeleteAsync($"api/patients/{id}");

        public async Task<List<MedicationDto>> GetMedicationsByPatientId(Guid patientId) =>
            await _httpClient.GetFromJsonAsync<List<MedicationDto>>($"api/patients/{patientId}/medications");

        public async Task<List<AllergyDto>> GeAllergiesByPatientId(Guid patientId) =>
        await _httpClient.GetFromJsonAsync<List<AllergyDto>>($"api/patients/{patientId}/allergies");
    }
}