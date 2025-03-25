using ClinicalNotesSummarization.SharedKernel.Events;
using MediatR;

namespace ClinicalNotesSummarization.Domain.DomainEvents
{
    public class ClinicalNoteSummarizedEvent : IDomainEvent, INotification
    {
        public Guid ClinicalNoteId { get; }
        public string Summary { get; }
        public DateTimeOffset OccurredOn { get; } = DateTime.UtcNow;

        public ClinicalNoteSummarizedEvent(Guid clinicalNoteId, string summary)
        {
            ClinicalNoteId = clinicalNoteId;
            Summary = summary;
        }
    }
}
