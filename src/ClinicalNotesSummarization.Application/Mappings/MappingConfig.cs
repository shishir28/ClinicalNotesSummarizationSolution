using ClinicalNotesSummarization.Application.Features.Medications.Commands;
using ClinicalNotesSummarization.Application.Features.Patients.Commands;
using ClinicalNotesSummarization.Application.Features.Patients.Queries;
using ClinicalNotesSummarization.Domain.Entities;
using Mapster;

namespace ClinicalNotesSummarization.Application.Mappings
{
    public static class MappingConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<CreatePatientCommand, Patient>
            .NewConfig()
            .ConstructUsing(src => new Patient(src.FirstName, src.LastName, src.DateOfBirth, src.Gender, src.PhoneNumber, src.Email, src.Address));

            TypeAdapterConfig<UpdatePatientCommand, Patient>
            .NewConfig()
            .ConstructUsing(src => new Patient( src.FirstName, src.LastName, src.DateOfBirth, src.Gender, src.PhoneNumber, src.Email, src.Address));

            TypeAdapterConfig<Patient, GetPatientByIdQueryResult>
           .NewConfig()
           .ConstructUsing(src => new GetPatientByIdQueryResult(src.FirstName, src.LastName, src.DateOfBirth, src.Gender, src.PhoneNumber, src.Email, src.Address));

            TypeAdapterConfig<CreateMedicationCommand, Medication>
            .NewConfig()
            .ConstructUsing(src => new Medication(src.PatientId, src.Name, src.Dosage, src.Frequency, src.PrescribingDoctor, src.StartDate, src.EndDate));

            TypeAdapterConfig<UpdateMedicationCommand, Medication>
            .NewConfig()
            .ConstructUsing(src => new Medication(src.PatientId, src.Name, src.Dosage, src.Frequency, src.PrescribingDoctor, src.StartDate, src.EndDate));

            // TypeAdapterConfig<Patient, GetPatientByIdQueryResult>
            //.NewConfig()
            //.ConstructUsing(src => new GetPatientByIdQueryResult(src.FirstName, src.LastName, src.DateOfBirth, src.Gender, src.PhoneNumber, src.Email, src.Address));

            TypeAdapterConfig.GlobalSettings.Compile(); // Compile for performance
        }
    }
}
