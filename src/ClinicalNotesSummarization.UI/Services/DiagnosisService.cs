using ClinicalNotesSummarization.UI.Models;

namespace ClinicalNotesSummarization.UI.Services
{
    public interface IDiagnosisService
    {
        Task<List<DiagnosisDto>> GetDiagnoses();
        Task<DiagnosisDto> GetDiagnosisById(Guid id);

        Task AddDiagnosis(DiagnosisDto medication);
        Task UpdateDiagnosis(DiagnosisDto medication);
        Task DeleteDiagnosis(Guid id);
    }

    public class DiagnosisService : IDiagnosisService
    {
        private readonly HttpClient _httpClient;

        public DiagnosisService(HttpClient httpClient) =>
            _httpClient = httpClient!;

        public async Task<List<DiagnosisDto>> GetDiagnoses() =>
          await _httpClient.GetFromJsonAsync<List<DiagnosisDto>>("api/diagnoses");

        public async Task<DiagnosisDto> GetDiagnosisById(Guid id) =>
            await _httpClient.GetFromJsonAsync<DiagnosisDto>($"api/diagnoses/{id}");

        public async Task<List<DiagnosisDto>> GetDiagnosesByPatientId(Guid patientId) =>
          await _httpClient.GetFromJsonAsync<List<DiagnosisDto>>("api/diagnoses/patient/{patientId}");

        public async Task AddDiagnosis(DiagnosisDto medication) =>
            await _httpClient.PostAsJsonAsync("api/diagnoses", medication);

        public async Task UpdateDiagnosis(DiagnosisDto medication) =>
            await _httpClient.PutAsJsonAsync($"api/diagnoses/{medication.Id}", medication);

        public async Task DeleteDiagnosis(Guid id) =>
            await _httpClient.DeleteAsync($"api/diagnoses/{id}");
    }
}
