using ClinicalNotesSummarization.SharedKernel.Entities;

namespace ClinicalNotesSummarization.Domain.Entities
{
    // Represents a medication prescribed to a patient
    public class Medication : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }  // Foreign Key
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string PrescribingDoctor { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        // Navigation Property
        public Patient Patient { get; set; }
    }
}
