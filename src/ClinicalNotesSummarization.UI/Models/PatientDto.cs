using ClinicalNotesSummarization.Domain.Entities;

namespace ClinicalNotesSummarization.UI.Models
{
    public class PatientDto
    {
        public Guid Id { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime? DateOfBirth { get; set; } = default!;
        public Gender Gender { get; set; }  // Enum: Male, Female, Other
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Address { get; set; } = default!;
    }

}
