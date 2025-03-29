using ClinicalNotesSummarization.Domain.Entities;

namespace ClinicalNotesSummarization.Domain.Repositories
{

    public interface IDiagnosisRepository
    {
        Task<Diagnosis?> GetByIdAsync(Guid Id);
        Task<List<Diagnosis>> GetByPatientIdAsync(Guid patientId);
        Task<List<Diagnosis>> GetAllAsync();
        Task<Guid> AddAsync(Diagnosis diagnosis);
        Task UpdateAsync(Diagnosis diagnosis);
        Task DeleteByIdAsync(Guid Id);
    }
}
