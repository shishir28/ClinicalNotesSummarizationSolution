using MediatR;

namespace ClinicalNotesSummarization.Application.Features.Medications.Commands
{
    public class CreateMedicationCommand : IRequest<Guid>
    {
        public string Name { get; set; } = default!;        
        public string Dosage { get; set; } = default!;
        public string Frequency { get; set; } = default!;
        public string PrescribingDoctor { get; set; } = default!;
        public DateTime StartDate { get; set; } = default!;
        public DateTime EndDate { get; set; } = default!;
        public Guid PatientId { get; set; }
    }

    public class UpdateMedicationCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Dosage { get; set; } = default!;
        public string Frequency { get; set; } = default!;
        public string PrescribingDoctor { get; set; } = default!;
        public DateTime StartDate { get; set; } = default!;
        public DateTime EndDate { get; set; } = default!;
        public Guid PatientId { get; set; }
    }

    public class DeleteMedicationCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
