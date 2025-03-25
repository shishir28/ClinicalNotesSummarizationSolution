using ClinicalNotesSummarization.Domain.Entities;
using MediatR;

namespace ClinicalNotesSummarization.Application.Features.Patients.Queries
{
    public class GetPatientByIdQuery : IRequest<GetPatientByIdQueryResult>
    {
        public Guid Id { get; set; } = default!;
        public GetPatientByIdQuery(Guid id)
        {
            Id = id;
        }
    }
        
    public class GetPatientByIdQueryResult 
    {
        public Guid Id { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTimeOffset DateOfBirth { get; set; } = default!;
        public Gender Gender { get; set; }  // Enum: Male, Female, Other
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Address { get; set; } = default!;

        public GetPatientByIdQueryResult(string firstName,
           string lastName,
           DateTimeOffset dateOfBirth,
           Gender gender,
           string phoneNumber,
           string email,
           string address)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
        }
    }

    public class GetAllPatientsQuery : IRequest<List<GetAllPatientsQueryResult>>
    {
    }

    public class GetAllPatientsQueryResult
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTimeOffset DateOfBirth { get; set; } = default!;
        public Gender Gender { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Address { get; set; } = default!;
    }
}
