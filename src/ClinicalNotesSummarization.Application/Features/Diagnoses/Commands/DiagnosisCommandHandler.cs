using ClinicalNotesSummarization.Domain.Entities;
using ClinicalNotesSummarization.Domain.Repositories;
using Mapster;
using MediatR;

namespace ClinicalNotesSummarization.Application.Features.Diagnoses.Commands
{
    public class DiagnosisCommandHandler : IRequestHandler<CreateDiagnosisCommand, Guid>,
        IRequestHandler<UpdateDiagnosisCommand>,
        IRequestHandler<DeleteDiagnosisCommand>
    {
        private IDiagnosisRepository _medicationRepository;

        public DiagnosisCommandHandler(IDiagnosisRepository medicationRepository) =>
            _medicationRepository = medicationRepository;

        public async Task<Guid> Handle(CreateDiagnosisCommand request, CancellationToken cancellationToken)
        {
            var medicationObject = request.Adapt<Diagnosis>();
            return await _medicationRepository.AddAsync(medicationObject);
        }

        public async Task Handle(UpdateDiagnosisCommand request, CancellationToken cancellationToken)
        {
            var medicationObject = request.Adapt<Diagnosis>();
            await _medicationRepository.UpdateAsync(medicationObject);
        }

        public async Task Handle(DeleteDiagnosisCommand request, CancellationToken cancellationToken) =>
         await _medicationRepository.DeleteByIdAsync(request.Id);
    }
}
