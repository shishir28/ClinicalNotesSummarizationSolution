using ClinicalNotesSummarization.Domain.Entities;

namespace ClinicalNotesSummarization.Domain.Repositories
{

    public interface IAllergyRepository
    {
        Task<Allergy?> GetByIdAsync(Guid Id);
        Task<List<Allergy>> GetByPatientIdAsync(Guid patientId);
        Task<List<Allergy>> GetAllAsync();
        Task<Guid> AddAsync(Allergy allergy);
        Task UpdateAsync(Allergy allergy);
        Task DeleteByIdAsync(Guid Id);
    }
}
