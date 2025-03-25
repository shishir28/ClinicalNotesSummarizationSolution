using ClinicalNotesSummarization.Domain.Entities;
using MediatR;

namespace ClinicalNotesSummarization.Application.Features.Patients.Commands
{
    public class CreatePatientCommand : IRequest<Guid>
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DateOfBirth { get; set; } = default!;
        public Gender Gender { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Address { get; set; } = default!;
    }

    public class UpdatePatientCommand : IRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DateOfBirth { get; set; } = default!;
        public Gender Gender { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Address { get; set; } = default!;
    }

    public class DeletePatientCommand: IRequest
    {
        public Guid Id { get; set; }
    }


}
