using MediatR;

namespace ClinicalNotesSummarization.Application.Features.Allergies.Commands
{
    public class CreateAllergyCommand : IRequest<Guid>
    {
        public string Allergen { get; set; } = default!;        
        public string Reaction { get; set; } = default!;
        public string Severity { get; set; } = default!;
        public DateTime RecordedDate { get; set; } = default!;
        public Guid PatientId { get; set; }
    }

    public class UpdateAllergyCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Allergen { get; set; } = default!;
        public string Reaction { get; set; } = default!;
        public string Severity { get; set; } = default!;
        public DateTime RecordedDate { get; set; } = default!;
        public Guid PatientId { get; set; }
    }

    public class DeleteAllergyCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
