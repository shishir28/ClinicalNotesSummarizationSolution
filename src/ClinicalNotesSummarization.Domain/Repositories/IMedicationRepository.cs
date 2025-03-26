using ClinicalNotesSummarization.Domain.Entities;

namespace ClinicalNotesSummarization.Domain.Repositories
{

    public interface IMedicationRepository
    {
        Task<Medication?> GetByIdAsync(Guid Id);
        Task<List<Medication>> GetByPatientIdAsync(Guid patientId);
        Task<List<Medication>> GetAllAsync();
        Task<Guid> AddAsync(Medication medication);
        Task UpdateAsync(Medication medication);
        Task DeleteByIdAsync(Guid Id);
    }
}
