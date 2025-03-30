using ClinicalNotesSummarization.Domain.Entities;
using ClinicalNotesSummarization.Domain.Repositories;
using Mapster;
using MediatR;

namespace ClinicalNotesSummarization.Application.Features.MedicalConditions.Commands
{
    public class MedicalConditionCommandHandler : IRequestHandler<CreateMedicalConditionCommand, Guid>,
        IRequestHandler<UpdateMedicalConditionCommand>,
        IRequestHandler<DeleteMedicalConditionCommand>
    {
        private IMedicalConditionRepository _medicationRepository;

        public MedicalConditionCommandHandler(IMedicalConditionRepository medicationRepository) =>
            _medicationRepository = medicationRepository;

        public async Task<Guid> Handle(CreateMedicalConditionCommand request, CancellationToken cancellationToken)
        {
            var medicationObject = request.Adapt<MedicalCondition>();
            return await _medicationRepository.AddAsync(medicationObject);
        }

        public async Task Handle(UpdateMedicalConditionCommand request, CancellationToken cancellationToken)
        {
            var medicationObject = request.Adapt<MedicalCondition>();
            await _medicationRepository.UpdateAsync(medicationObject);
        }

        public async Task Handle(DeleteMedicalConditionCommand request, CancellationToken cancellationToken) =>
         await _medicationRepository.DeleteByIdAsync(request.Id);
    }
}
