using MediatR;

namespace ClinicalNotesSummarization.Application.Features.MedicalConditions.Commands
{
    public class CreateMedicalConditionCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Symptoms { get; set; }
        public string Causes { get; set; }
        public string Treatments { get; set; }
        public string Severity { get; set; }
        public Guid PatientId { get; set; }
    }

    public class UpdateMedicalConditionCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Symptoms { get; set; }
        public string Causes { get; set; }
        public string Treatments { get; set; }
        public string Severity { get; set; }
        public Guid PatientId { get; set; }
    }

    public class DeleteMedicalConditionCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
