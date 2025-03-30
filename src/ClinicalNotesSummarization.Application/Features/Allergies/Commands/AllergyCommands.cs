using MediatR;

namespace ClinicalNotesSummarization.Application.Features.Allergies.Commands
{
    public class CreateAllergyCommand : IRequest<Guid>
    {
        public string Name { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string Severity { get; set; }  = default!; // Enum: Mild, Moderate, Severe
        public string Symptoms { get; set; } = default!;
        public string CommonTriggers { get; set; } = default!;
        public DateTime RecordedDate { get; set; } = default!;
        public Guid PatientId { get; set; }
    }

    public class UpdateAllergyCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Type { get; set; } = default!;

        public string Severity { get; set; } = default!; // Enum: Mild, Moderate, Severe
        public string Symptoms { get; set; } = default!;
        public string CommonTriggers { get; set; } = default!;
        public DateTime RecordedDate { get; set; } = default!;
        public Guid PatientId { get; set; }
    }

    public class DeleteAllergyCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
