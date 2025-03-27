using ClinicalNotesSummarization.Domain.Entities;
using ClinicalNotesSummarization.Domain.Repositories;
using Mapster;
using MediatR;

namespace ClinicalNotesSummarization.Application.Features.Allergies.Commands
{
    public class AllergyCommandHandler : IRequestHandler<CreateAllergyCommand, Guid>,
        IRequestHandler<UpdateAllergyCommand>,
        IRequestHandler<DeleteAllergyCommand>
    {
        private IMedicationRepository _medicationRepository;

        public AllergyCommandHandler(IMedicationRepository medicationRepository) =>
            _medicationRepository = medicationRepository;

        public async Task<Guid> Handle(CreateAllergyCommand request, CancellationToken cancellationToken)
        {
            var medicationObject = request.Adapt<Medication>();
            return await _medicationRepository.AddAsync(medicationObject);
        }

        public async Task Handle(UpdateAllergyCommand request, CancellationToken cancellationToken)
        {
            var medicationObject = request.Adapt<Medication>();
            await _medicationRepository.UpdateAsync(medicationObject);
        }

        public async Task Handle(DeleteAllergyCommand request, CancellationToken cancellationToken) =>
         await _medicationRepository.DeleteByIdAsync(request.Id);
    }
}
