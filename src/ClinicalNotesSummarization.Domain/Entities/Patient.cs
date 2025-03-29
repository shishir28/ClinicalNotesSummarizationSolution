using ClinicalNotesSummarization.Domain.DomainEvents;
using ClinicalNotesSummarization.SharedKernel.Entities;

namespace ClinicalNotesSummarization.Domain.Entities
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public class Patient : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public Gender Gender { get; set; }  // Enum: Male, Female, Other
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        // Foreign Keys & Navigation Properties
        public ICollection<ClinicalNote> ClinicalNotes { get; set; } = [];
        public ICollection<Allergy> Allergies { get; set; } = [];
        public ICollection<Medication> Medications { get; set; } = [];
        public ICollection<MedicalCondition> MedicalConditions { get; set; } = [];
        public ICollection<Appointment> Appointments { get; set; } = [];

        // Auditing Fields
        public DateTimeOffset CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTimeOffset? UpdatedAt { get; set; } = DateTime.UtcNow;

        public Patient(string firstName,
            string lastName,
            DateTimeOffset dateOfBirth,
            Gender gender,
            string phoneNumber,
            string email,
            string address)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            AddDomainEvent(new PatientCreatedEvent(Id, FirstName, LastName));
        }

        public void Update(string firstName,
            string lastName,
            DateTimeOffset dateOfBirth,
            Gender gender,
            string phoneNumber,
            string email)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Email = email;

            AddDomainEvent(new PatientUpdatedEvent(Id, FirstName, LastName, dateOfBirth, gender, PhoneNumber, Email));
        }
    }
}
