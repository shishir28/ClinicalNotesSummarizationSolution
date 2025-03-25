using ClinicalNotesSummarization.UI.Models;

namespace ClinicalNotesSummarization.UI.Services
{
    public interface IPatientService
    {
        Task<List<PatientDto>> GetPatients();
        Task<PatientDto> GetPatientById(Guid id);
        Task AddPatient(PatientDto patient);
        Task UpdatePatient(PatientDto patient);
        Task DeletePatient(Guid id);
    }
}
