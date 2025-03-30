using ClinicalNotesSummarization.Domain.Entities;

namespace ClinicalNotesSummarization.Domain.Repositories
{

    public interface IMedicalConditionRepository
    {
        Task<MedicalCondition?> GetByIdAsync(Guid Id);
        Task<List<MedicalCondition>> GetByPatientIdAsync(Guid patientId);
        Task<List<MedicalCondition>> GetAllAsync();
        Task<Guid> AddAsync(MedicalCondition medication);
        Task UpdateAsync(MedicalCondition medication);
        Task DeleteByIdAsync(Guid Id);
    }
}
