using ClinicalNotesSummarization.SharedKernel.Entities;

namespace ClinicalNotesSummarization.Domain.Entities
{
    public class Allergy : BaseEntity
    {

        public Guid PatientId { get; set; }  // Foreign Key
        public string Name { get; set; }
        public string Type { get; set; }
        
        public string Severity { get; set; }  // Enum: Mild, Moderate, Severe
        public string Symptoms { get; set; }
        public string CommonTriggers { get; set; }
        public DateTimeOffset? RecordedDate { get; set; }

        // Navigation Property
        public Patient Patient { get; set; }

        public Allergy(Guid patientId,
            string name,
            string type,
            string severity,
            string symptoms,
            string commonTriggers,
            DateTimeOffset? recordedDate)
        {
            PatientId = patientId;
            Name = name;
            Type = type;
            Severity = severity;
            Symptoms = symptoms;
            CommonTriggers = commonTriggers;
            RecordedDate = recordedDate;
        }
    }
}
