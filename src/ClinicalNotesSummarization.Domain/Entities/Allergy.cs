using ClinicalNotesSummarization.SharedKernel.Entities;

namespace ClinicalNotesSummarization.Domain.Entities
{
    public class Allergy : BaseEntity
    {

        public Guid PatientId { get; set; }  // Foreign Key
        public string Allergen { get; set; }
        public string Reaction { get; set; }
        public string Severity { get; set; }  // Enum: Mild, Moderate, Severe
        public DateTimeOffset? RecordedDate { get; set; }

        // Navigation Property
        public Patient Patient { get; set; }

        public Allergy(Guid patientId, string allergen, string reaction, string severity, DateTimeOffset? recordedDate)
        {
            PatientId = patientId;
            Allergen = allergen;
            Reaction = reaction;
            Severity = severity;
            RecordedDate = recordedDate;
        }
    }
}
