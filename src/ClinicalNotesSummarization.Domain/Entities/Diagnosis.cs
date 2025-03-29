using ClinicalNotesSummarization.SharedKernel.Entities;

namespace ClinicalNotesSummarization.Domain.Entities
{
    // Represents a diagnosis assigned to a patient
    public class Diagnosis : BaseEntity
    {
        public Guid PatientId { get; private set; }
        public string Code { get; private set; } // ICD-10 or other medical code
        public string Description { get; private set; }
        public string Severity { get; set; }
        public string PrescribingDoctor { get; set; }
        public string Notes { get; set; }

        public DateTimeOffset DiagnosedOn { get; private set; }

        private Diagnosis() { } // For EF Core

        public Diagnosis(Guid patientId, string code, string description, string severity, string prescribingDoctor, string notes, DateTimeOffset diagnosedOn)
        {
            PatientId = patientId;
            Code = code;
            Description = description;
            Severity = severity;
            PrescribingDoctor = prescribingDoctor;
            Notes = notes;
            DiagnosedOn = diagnosedOn;
        }
    }
}
