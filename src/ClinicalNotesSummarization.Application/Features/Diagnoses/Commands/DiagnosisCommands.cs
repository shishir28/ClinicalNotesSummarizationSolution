using MediatR;

namespace ClinicalNotesSummarization.Application.Features.Diagnoses.Commands
{
    public class CreateDiagnosisCommand : IRequest<Guid>
    {
        public string Code { get; set; } = default!;        
        public string Description { get; set; } = default!;
        public string Severity { get; set; } = default!;
        public string PrescribingDoctor { get; set; } = default!;
        public string Notes { get; set; } = default!;
        public DateTime DiagnosedOn { get; set; } = default!;
        public Guid PatientId { get; set; }
    }

    public class UpdateDiagnosisCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Severity { get; set; } = default!;
        public string PrescribingDoctor { get; set; } = default!;
        public string Notes { get; set; } = default!;
        public DateTime DiagnosedOn { get; set; } = default!;
        public Guid PatientId { get; set; }
    }

    public class DeleteDiagnosisCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
