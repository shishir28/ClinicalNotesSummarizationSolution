using ClinicalNotesSummarization.Domain.Entities;

namespace ClinicalNotesSummarization.Domain.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient?> GetByIdAsync(Guid id);
        Task<List<Patient>> GetAllAsync();
        Task<Guid> AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task DeleteByIdAsync(Guid Id);
    }
}
