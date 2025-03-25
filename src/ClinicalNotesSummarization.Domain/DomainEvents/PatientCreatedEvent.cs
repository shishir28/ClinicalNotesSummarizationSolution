using ClinicalNotesSummarization.SharedKernel.Events;
using MediatR;

namespace ClinicalNotesSummarization.Domain.DomainEvents
{
    public class PatientCreatedEvent : IDomainEvent, INotification  
    {
        public Guid PatientId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTimeOffset OccurredOn { get; } = DateTime.UtcNow;        
        public PatientCreatedEvent(Guid patientId, string firstName, string lastName)
        {
            PatientId = patientId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
