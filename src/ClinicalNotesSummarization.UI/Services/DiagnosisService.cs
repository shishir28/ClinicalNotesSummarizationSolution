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

        public async Task<List<DiagnosisDto>> GetDiagnoses()
        {
            var diagnoses = await _httpClient.GetFromJsonAsync<List<DiagnosisDto>>("api/diagnoses");
            return diagnoses ?? [];
        }

        public async Task<DiagnosisDto> GetDiagnosisById(Guid id)
        {
            var diagnosis = await _httpClient.GetFromJsonAsync<DiagnosisDto>($"api/diagnoses/{id}") ?? throw new InvalidOperationException($"Diagnosis with id {id} not found.");
            return diagnosis;
        }

        public async Task<List<DiagnosisDto>> GetDiagnosesByPatientId(Guid patientId)
        {
            var diagnoses = await _httpClient.GetFromJsonAsync<List<DiagnosisDto>>($"api/diagnoses/patient/{patientId}");
            return diagnoses ?? [];
        }

        public async Task AddDiagnosis(DiagnosisDto medication) =>
            await _httpClient.PostAsJsonAsync("api/diagnoses", medication);

        public async Task UpdateDiagnosis(DiagnosisDto medication) =>
            await _httpClient.PutAsJsonAsync($"api/diagnoses/{medication.Id}", medication);

        public async Task DeleteDiagnosis(Guid id) =>
            await _httpClient.DeleteAsync($"api/diagnoses/{id}");
    }
}
