using ClinicalNotesSummarization.SharedKernel.Entities;

namespace ClinicalNotesSummarization.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public Guid PatientId { get; set; }  // Foreign Key
        public DateTimeOffset AppointmentDate { get; set; }
        public string DoctorName { get; set; }
        public string Notes { get; set; }

        // Embedding metadata
        public string? EmbeddingHash { get; set; }
        public DateTimeOffset? EmbeddingIndexedAt { get; set; }

        // Navigation Property
        public Patient Patient { get; set; }
    }
}
