using ClinicalNotesSummarization.Domain.Repositories;
using Mapster;
using MediatR;

namespace ClinicalNotesSummarization.Application.Features.Medications.Queries
{
    public class MedicationQueryHandler : IRequestHandler<GetMedicationIdQuery, GetMedicationByIdQueryResult>,
                                          IRequestHandler<GetAllMedicationQuery, List<GetAllMedicationQueryResult>>,
                                          IRequestHandler<GetAllMedicationByPatientIdQuery, List<GetAllMedicationByPatientIdQueryResult>>
    {
        private IMedicationRepository _medicationRepository;

        public MedicationQueryHandler(IMedicationRepository medicationRepository) =>
            _medicationRepository = medicationRepository;

        public async Task<GetMedicationByIdQueryResult> Handle(GetMedicationIdQuery request, CancellationToken cancellationToken)
        {
            var medication = await _medicationRepository.GetByIdAsync(request.Id);
            return medication.Adapt<GetMedicationByIdQueryResult>();
        }

        public async Task<List<GetAllMedicationQueryResult>> Handle(GetAllMedicationQuery request, CancellationToken cancellationToken)
        {
            var medications = await _medicationRepository.GetAllAsync();
            return medications.Adapt<List<GetAllMedicationQueryResult>>();
        }

        public async Task<List<GetAllMedicationByPatientIdQueryResult>> Handle(GetAllMedicationByPatientIdQuery request, CancellationToken cancellationToken)
        {
            var medications = await _medicationRepository.GetByPatientIdAsync(request.PatientId);
            return medications.Adapt<List<GetAllMedicationByPatientIdQueryResult>>();
        }
    }
}