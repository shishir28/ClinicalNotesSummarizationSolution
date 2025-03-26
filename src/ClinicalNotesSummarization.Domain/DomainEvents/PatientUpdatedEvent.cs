using ClinicalNotesSummarization.Domain.Entities;
using ClinicalNotesSummarization.SharedKernel.Events;
using MediatR;

namespace ClinicalNotesSummarization.Domain.DomainEvents
{
    public class PatientUpdatedEvent : IDomainEvent, INotification
    {
        public Guid PatientId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTimeOffset DateOfBirth { get; }
        public Gender Gender { get; }
        public string PhoneNumber { get; }
        public string Email { get; }

        public DateTimeOffset OccurredOn { get; } = DateTime.UtcNow;

        public PatientUpdatedEvent(Guid patientId, string firstName, string lastName, DateTimeOffset dateOfBirth, Gender gender, string phoneNumber, string email)
        {
            PatientId = patientId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
