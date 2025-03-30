using ClinicalNotesSummarization.Domain.Repositories;
using Mapster;
using MediatR;

namespace ClinicalNotesSummarization.Application.Features.MedicalConditions.Queries
{
    public class MedicalConditionQueryHandler : IRequestHandler<GetMedicalConditionIdQuery, GetMedicalConditionByIdQueryResult>,
                                          IRequestHandler<GetAllMedicalConditionQuery, List<GetAllMedicalConditionQueryResult>>,
                                          IRequestHandler<GetAllMedicalConditionByPatientIdQuery, List<GetAllMedicalConditionByPatientIdQueryResult>>
    {
        private IMedicalConditionRepository _medicationRepository;

        public MedicalConditionQueryHandler(IMedicalConditionRepository medicationRepository) =>
            _medicationRepository = medicationRepository;

        public async Task<GetMedicalConditionByIdQueryResult> Handle(GetMedicalConditionIdQuery request, CancellationToken cancellationToken)
        {
            var medication = await _medicationRepository.GetByIdAsync(request.Id);
            return medication.Adapt<GetMedicalConditionByIdQueryResult>();
        }

        public async Task<List<GetAllMedicalConditionQueryResult>> Handle(GetAllMedicalConditionQuery request, CancellationToken cancellationToken)
        {
            var medications = await _medicationRepository.GetAllAsync();
            return medications.Adapt<List<GetAllMedicalConditionQueryResult>>();
        }

        public async Task<List<GetAllMedicalConditionByPatientIdQueryResult>> Handle(GetAllMedicalConditionByPatientIdQuery request, CancellationToken cancellationToken)
        {
            var medications = await _medicationRepository.GetByPatientIdAsync(request.PatientId);
            return medications.Adapt<List<GetAllMedicalConditionByPatientIdQueryResult>>();
        }
    }
}