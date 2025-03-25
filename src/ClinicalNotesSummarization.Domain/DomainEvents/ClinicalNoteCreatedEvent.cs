using ClinicalNotesSummarization.SharedKernel.Events;
using MediatR;

namespace ClinicalNotesSummarization.Domain.DomainEvents
{
    public class ClinicalNoteCreatedEvent : IDomainEvent, INotification
    {
        public Guid ClinicalNoteId { get; }
        public DateTimeOffset OccurredOn { get; } = DateTime.UtcNow;

        public ClinicalNoteCreatedEvent(Guid clinicalNoteId)
        {
            ClinicalNoteId = clinicalNoteId;
        }
    }
}
