using ClinicalNotesSummarization.Domain.Entities;
using ClinicalNotesSummarization.Domain.Repositories;
using MediatR;
using Mapster;

namespace ClinicalNotesSummarization.Application.Features.Patients.Commands
{
    public class PatientCommandHandler : IRequestHandler<CreatePatientCommand, Guid>,
                                         IRequestHandler<UpdatePatientCommand>,
                                         IRequestHandler<DeletePatientCommand>
    {
        private IPatientRepository _patientRepository;

        public PatientCommandHandler(IPatientRepository patientRepository) =>
            _patientRepository = patientRepository;

        public async Task<Guid> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var patientObject = request.Adapt<Patient>();
            return await _patientRepository.AddAsync(patientObject);
        }

        public async Task Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patientObject = request.Adapt<Patient>();
            await _patientRepository.UpdateAsync(patientObject);
        }

        public async Task Handle(DeletePatientCommand request, CancellationToken cancellationToken) =>
            await _patientRepository.DeleteByIdAsync(request.Id);
    }
}
