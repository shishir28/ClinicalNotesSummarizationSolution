using ClinicalNotesSummarization.UI.Models;

namespace ClinicalNotesSummarization.UI.Services
{
    public interface IMedicalConditionService
    {
        Task<List<MedicalConditionDto>> GetMedicalConditions();
        Task<MedicalConditionDto> GetMedicalConditionById(Guid id);

        Task AddMedicalCondition(MedicalConditionDto medication);
        Task UpdateMedicalCondition(MedicalConditionDto medication);
        Task DeleteMedicalCondition(Guid id);
    }

    public class MedicalConditionService : IMedicalConditionService
    {
        private readonly HttpClient _httpClient;

        public MedicalConditionService(HttpClient httpClient) =>
            _httpClient = httpClient!;

        public async Task<List<MedicalConditionDto>> GetMedicalConditions() =>
          await _httpClient.GetFromJsonAsync<List<MedicalConditionDto>>("api/medicalconditions");

        public async Task<MedicalConditionDto> GetMedicalConditionById(Guid id) =>
            await _httpClient.GetFromJsonAsync<MedicalConditionDto>($"api/medicalconditions/{id}");

        public async Task<List<MedicalConditionDto>> GetMedicalConditionsByPatientId(Guid patientId) =>
          await _httpClient.GetFromJsonAsync<List<MedicalConditionDto>>("api/medicalconditions/patient/{patientId}");

        public async Task AddMedicalCondition(MedicalConditionDto medication) =>
            await _httpClient.PostAsJsonAsync("api/medicalconditions", medication);

        public async Task UpdateMedicalCondition(MedicalConditionDto medication) =>
            await _httpClient.PutAsJsonAsync($"api/medicalconditions/{medication.Id}", medication);

        public async Task DeleteMedicalCondition(Guid id) =>
            await _httpClient.DeleteAsync($"api/medicalconditions/{id}");
    }
}
