using ClinicalNotesSummarization.Domain.Repositories;
using Mapster;
using MediatR;

namespace ClinicalNotesSummarization.Application.Features.Patients.Queries
{
    public class PatientQueryHandler : IRequestHandler<GetPatientByIdQuery, GetPatientByIdQueryResult>,
                                       IRequestHandler<GetAllPatientsQuery, List<GetAllPatientsQueryResult>>
    {
        private IPatientRepository _patientRepository;

        public PatientQueryHandler(IPatientRepository patientRepository) =>
            _patientRepository = patientRepository;

        public async Task<GetPatientByIdQueryResult> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetByIdAsync(request.Id);
            return patient.Adapt<GetPatientByIdQueryResult>();
        }

        public async Task<List<GetAllPatientsQueryResult>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            var patients = await _patientRepository.GetAllAsync();
            return patients.Adapt<List<GetAllPatientsQueryResult>>();
        }
    }
}
