using ClinicalNotesSummarization.Domain.Repositories;
using Mapster;
using MediatR;

namespace ClinicalNotesSummarization.Application.Features.Diagnoses.Queries
{
    public class DiagnosisQueryHandler : IRequestHandler<GetDiagnosisIdQuery, GetDiagnosisByIdQueryResult>,
                                          IRequestHandler<GetAllDiagnosisQuery, List<GetAllDiagnosisQueryResult>>,
                                          IRequestHandler<GetAllDiagnosisByPatientIdQuery, List<GetAllDiagnosisByPatientIdQueryResult>>
    {
        private IDiagnosisRepository _diagnosisRepository;

        public DiagnosisQueryHandler(IDiagnosisRepository diagnosisRepository) =>
            _diagnosisRepository = diagnosisRepository;

        public async Task<GetDiagnosisByIdQueryResult> Handle(GetDiagnosisIdQuery request, CancellationToken cancellationToken)
        {
            var diagnosis = await _diagnosisRepository.GetByIdAsync(request.Id);
            return diagnosis.Adapt<GetDiagnosisByIdQueryResult>();
        }

        public async Task<List<GetAllDiagnosisQueryResult>> Handle(GetAllDiagnosisQuery request, CancellationToken cancellationToken)
        {
            var diagnoses = await _diagnosisRepository.GetAllAsync();
            return diagnoses.Adapt<List<GetAllDiagnosisQueryResult>>();
        }

        public async Task<List<GetAllDiagnosisByPatientIdQueryResult>> Handle(GetAllDiagnosisByPatientIdQuery request, CancellationToken cancellationToken)
        {
            var diagnoses = await _diagnosisRepository.GetByPatientIdAsync(request.PatientId);
            return diagnoses.Adapt<List<GetAllDiagnosisByPatientIdQueryResult>>();
        }
    }
}