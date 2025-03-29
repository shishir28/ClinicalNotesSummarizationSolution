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
        private IAllergyRepository _allergyRepository;

        public AllergyCommandHandler(IAllergyRepository allergyRepository) =>
            _allergyRepository = allergyRepository;

        public async Task<Guid> Handle(CreateAllergyCommand request, CancellationToken cancellationToken)
        {
            var allergyObject = request.Adapt<Allergy>();
            return await _allergyRepository.AddAsync(allergyObject);
        }

        public async Task Handle(UpdateAllergyCommand request, CancellationToken cancellationToken)
        {
            var allergyObject = request.Adapt<Allergy>();
            await _allergyRepository.UpdateAsync(allergyObject);
        }

        public async Task Handle(DeleteAllergyCommand request, CancellationToken cancellationToken) =>
         await _allergyRepository.DeleteByIdAsync(request.Id);
    }
}
