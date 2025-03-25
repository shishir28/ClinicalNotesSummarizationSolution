using ClinicalNotesSummarization.Application.Features.Patients.Commands;
using ClinicalNotesSummarization.UI.Models;
using Mapster;

namespace ClinicalNotesSummarization.UI
{
    public static class MappingConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<CreatePatientCommand, PatientDto>
            .NewConfig()
            .ConstructUsing(src => new PatientDto { 
                FirstName = src.FirstName,
                LastName = src.LastName,
                DateOfBirth = src.DateOfBirth,
                Gender = src.Gender,
                Email = src.Email,
                PhoneNumber = src.PhoneNumber,
                Address = src.Address
            });

            TypeAdapterConfig.GlobalSettings.Compile(); // Compile for performance
        }
    }
}
