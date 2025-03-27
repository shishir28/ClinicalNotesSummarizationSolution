using ClinicalNotesSummarization.Domain.Repositories;
using Mapster;
using MediatR;

namespace ClinicalNotesSummarization.Application.Features.Allergies.Queries
{
    public class AllergyQueryHandler : IRequestHandler<GetAllergyIdQuery, GetAllergyByIdQueryResult>,
                                          IRequestHandler<GetAllAllergyQuery, List<GetAllAllergyQueryResult>>,
                                          IRequestHandler<GetAllAllergyByPatientIdQuery, List<GetAllAllergyByPatientIdQueryResult>>
    {
        private IAllergyRepository _allergyRepository;

        public AllergyQueryHandler(IAllergyRepository allergyRepository) =>
            _allergyRepository = allergyRepository;

        public async Task<GetAllergyByIdQueryResult> Handle(GetAllergyIdQuery request, CancellationToken cancellationToken)
        {
            var allergy = await _allergyRepository.GetByIdAsync(request.Id);
            return allergy.Adapt<GetAllergyByIdQueryResult>();
        }

        public async Task<List<GetAllAllergyQueryResult>> Handle(GetAllAllergyQuery request, CancellationToken cancellationToken)
        {
            var allergies = await _allergyRepository.GetAllAsync();
            return allergies.Adapt<List<GetAllAllergyQueryResult>>();
        }

        public async Task<List<GetAllAllergyByPatientIdQueryResult>> Handle(GetAllAllergyByPatientIdQuery request, CancellationToken cancellationToken)
        {
            var allergies = await _allergyRepository.GetByPatientIdAsync(request.PatientId);
            return allergies.Adapt<List<GetAllAllergyByPatientIdQueryResult>>();
        }
    }
}