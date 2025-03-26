using ClinicalNotesSummarization.UI.Models;

namespace ClinicalNotesSummarization.UI.Services
{
    public interface IMedicationService
    {
        Task<List<MedicationDto>> GetMedications();
        Task<MedicationDto> GetMedicationById(Guid id);

        Task AddMedication(MedicationDto medication);
        Task UpdateMedication(MedicationDto medication);
        Task DeleteMedication(Guid id);
    }

    public class MedicationService : IMedicationService
    {
        private readonly HttpClient _httpClient;

        public MedicationService(HttpClient httpClient) =>
            _httpClient = httpClient!;

        public async Task<List<MedicationDto>> GetMedications() =>
          await _httpClient.GetFromJsonAsync<List<MedicationDto>>("api/medications");

        public async Task<MedicationDto> GetMedicationById(Guid id) =>
            await _httpClient.GetFromJsonAsync<MedicationDto>($"api/medications/{id}");

        public async Task<List<MedicationDto>> GetMedicationsByPatientId(Guid patientId) =>
          await _httpClient.GetFromJsonAsync<List<MedicationDto>>("api/medications/patient/{patientId}");

        public async Task AddMedication(MedicationDto medication) =>
            await _httpClient.PostAsJsonAsync("api/medications", medication);

        public async Task UpdateMedication(MedicationDto medication) =>
            await _httpClient.PutAsJsonAsync($"api/medications/{medication.Id}", medication);

        public async Task DeleteMedication(Guid id) =>
            await _httpClient.DeleteAsync($"api/medications/{id}");
    }
}
