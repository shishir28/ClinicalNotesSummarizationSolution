using ClinicalNotesSummarization.Application.Features.Medications.Commands;
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
            .ConstructUsing(src => new PatientDto
            {
                FirstName = src.FirstName,
                LastName = src.LastName,
                DateOfBirth = src.DateOfBirth,
                Gender = src.Gender,
                Email = src.Email,
                PhoneNumber = src.PhoneNumber,
                Address = src.Address
            });


            TypeAdapterConfig<CreateMedicationCommand, MedicationDto>
          .NewConfig()
          .ConstructUsing(src => new MedicationDto
          {
              PatientId = src.PatientId,
              Name = src.Name,
              Dosage = src.Dosage,
              Frequency = src.Frequency,
              PrescribingDoctor = src.PrescribingDoctor,
              StartDate = src.StartDate,
              EndDate = src.EndDate
          });

            TypeAdapterConfig.GlobalSettings.Compile(); // Compile for performance
        }
    }
}