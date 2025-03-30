using MediatR;

namespace ClinicalNotesSummarization.Application.Features.MedicalConditions.Commands
{
    public class CreateMedicalConditionCommand : IRequest<Guid>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Symptoms { get; set; } = default!;
        public string Causes { get; set; } = default!;
        public string Treatments { get; set; } = default!;
        public string Severity { get; set; } = default!;
        public Guid PatientId { get; set; }   
    }

    public class UpdateMedicalConditionCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Symptoms { get; set; } = default!;
        public string Causes { get; set; } = default!;
        public string Treatments { get; set; } = default!;
        public string Severity { get; set; } = default!;
        public Guid PatientId { get; set; }
    }

    public class DeleteMedicalConditionCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
