using ClinicalNotesSummarization.Domain.Entities;
using ClinicalNotesSummarization.Domain.Repositories;
using Mapster;
using MediatR;

namespace ClinicalNotesSummarization.Application.Features.Medications.Commands
{
    public class MedicationCommandHandler : IRequestHandler<CreateMedicationCommand, Guid>,
        IRequestHandler<UpdateMedicationCommand>,
        IRequestHandler<DeleteMedicationCommand>
    {
        private IMedicationRepository _medicationRepository;

        public MedicationCommandHandler(IMedicationRepository medicationRepository) =>
            _medicationRepository = medicationRepository;

        public async Task<Guid> Handle(CreateMedicationCommand request, CancellationToken cancellationToken)
        {
            var medicationObject = request.Adapt<Medication>();
            return await _medicationRepository.AddAsync(medicationObject);
        }

        public async Task Handle(UpdateMedicationCommand request, CancellationToken cancellationToken)
        {
            var medicationObject = request.Adapt<Medication>();
            await _medicationRepository.UpdateAsync(medicationObject);
        }

        public async Task Handle(DeleteMedicationCommand request, CancellationToken cancellationToken) =>
         await _medicationRepository.DeleteByIdAsync(request.Id);
    }
}
