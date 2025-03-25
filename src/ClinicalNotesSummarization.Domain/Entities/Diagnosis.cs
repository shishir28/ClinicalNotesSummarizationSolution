using ClinicalNotesSummarization.SharedKernel.Entities;

namespace ClinicalNotesSummarization.Domain.Entities
{
    // Represents a diagnosis assigned to a patient
    public class Diagnosis : BaseEntity
    {
        public Guid PatientId { get; private set; }
        public string Code { get; private set; } // ICD-10 or other medical code
        public string Description { get; private set; }
        public DateTimeOffset DiagnosedOn { get; private set; }

        private Diagnosis() { } // For EF Core

        public Diagnosis(Guid patientId, string code, string description)
        {
            PatientId = patientId;
            Code = code;
            Description = description;
            DiagnosedOn = DateTime.UtcNow;
        }
    }
}
