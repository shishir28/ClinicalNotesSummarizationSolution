using ClinicalNotesSummarization.Application.Features.Medications.Commands;
using ClinicalNotesSummarization.Application.Features.Patients.Commands;
using ClinicalNotesSummarization.Application.Features.Allergies.Commands;
using ClinicalNotesSummarization.UI.Models;
using Mapster;
using ClinicalNotesSummarization.Application.Features.Diagnoses.Commands;

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

            TypeAdapterConfig<CreateAllergyCommand, AllergyDto>
             .NewConfig()
             .ConstructUsing(src => new AllergyDto
             {
                 PatientId = src.PatientId,
                 Name = src.Name,
                 Type = src.Type,
                 Severity = src.Severity,
                 Symptoms = src.Symptoms,
                 CommonTriggers = src.CommonTriggers,
                 RecordedDate = src.RecordedDate,
             });

            TypeAdapterConfig<CreateDiagnosisCommand, DiagnosisDto>
          .NewConfig()
          .ConstructUsing(src => new DiagnosisDto
          {
              PatientId = src.PatientId,
              Code = src.Code,
              Description = src.Description,
              Severity = src.Severity,
              PrescribingDoctor = src.PrescribingDoctor,
              Notes = src.Notes,
              DiagnosedOn = src.DiagnosedOn,
          });


            TypeAdapterConfig.GlobalSettings.Compile(); // Compile for performance
        }
    }
}