using ClinicalNotesSummarization.SharedKernel.Entities;

namespace ClinicalNotesSummarization.Domain.Entities
{
    public class MedicalCondition : BaseEntity
    {
        public Guid PatientId { get; set; }  // Foreign Key
        public string ConditionName { get; set; }
        public string Status { get; set; }  // Enum: Active, Resolved, Chronic
        public DateTimeOffset DiagnosedOn { get; set; }

        // Navigation Property
        public Patient Patient { get; set; }
    }
}
