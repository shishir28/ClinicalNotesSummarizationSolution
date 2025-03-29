using ClinicalNotesSummarization.UI.Models;

namespace ClinicalNotesSummarization.UI.Services
{
    public interface IAllergyService
    {
        Task<List<AllergyDto>> GetAllergys();
        Task<AllergyDto> GetAllergyById(Guid id);

        Task AddAllergy(AllergyDto Allergy);
        Task UpdateAllergy(AllergyDto Allergy);
        Task DeleteAllergy(Guid id);
    }

    public class AllergyService : IAllergyService
    {
        private readonly HttpClient _httpClient;

        public AllergyService(HttpClient httpClient) =>
            _httpClient = httpClient!;

        public async Task<List<AllergyDto>> GetAllergys() =>
          await _httpClient.GetFromJsonAsync<List<AllergyDto>>("api/allergies");

        public async Task<AllergyDto> GetAllergyById(Guid id) =>
            await _httpClient.GetFromJsonAsync<AllergyDto>($"api/allergies/{id}");

        public async Task<List<AllergyDto>> GetAllergysByPatientId(Guid patientId) =>
          await _httpClient.GetFromJsonAsync<List<AllergyDto>>("api/allergies/patient/{patientId}");

        public async Task AddAllergy(AllergyDto Allergy) =>
            await _httpClient.PostAsJsonAsync("api/allergies", Allergy);

        public async Task UpdateAllergy(AllergyDto Allergy) =>
            await _httpClient.PutAsJsonAsync($"api/allergies/{Allergy.Id}", Allergy);

        public async Task DeleteAllergy(Guid id) =>
            await _httpClient.DeleteAsync($"api/allergies/{id}");
    }
}
