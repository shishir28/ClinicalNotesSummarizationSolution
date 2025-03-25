using ClinicalNotesSummarization.Domain.DomainEvents;
using ClinicalNotesSummarization.SharedKernel.Entities;

namespace ClinicalNotesSummarization.Domain.Entities
{
    public class ClinicalNote : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }  // Foreign Key
        public string Summary { get; set; }  // AI-generated summary
        public string OriginalText { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Property
        public Patient Patient { get; set; }

        public void UpdateSummary(string summary)
        {
            Summary = summary;
            AddDomainEvent(new ClinicalNoteSummarizedEvent(Id, summary));
        }
    }
}
