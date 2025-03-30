using ClinicalNotesSummarization.Application.Features.Allergies.Commands;
using ClinicalNotesSummarization.Application.Features.Diagnoses.Commands;
using ClinicalNotesSummarization.Application.Features.MedicalConditions.Commands;
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
            .ConstructUsing(src => new Patient(src.FirstName, src.LastName, src.DateOfBirth, src.Gender, src.PhoneNumber, src.Email, src.Address));

            TypeAdapterConfig<Patient, GetPatientByIdQueryResult>
           .NewConfig()
           .ConstructUsing(src => new GetPatientByIdQueryResult(src.FirstName, src.LastName, src.DateOfBirth, src.Gender, src.PhoneNumber, src.Email, src.Address));

            TypeAdapterConfig<CreateMedicationCommand, Medication>
            .NewConfig()
            .ConstructUsing(src => new Medication(src.PatientId, src.Name, src.Dosage, src.Frequency, src.PrescribingDoctor, src.StartDate, src.EndDate));

            TypeAdapterConfig<UpdateMedicationCommand, Medication>
            .NewConfig()
            .ConstructUsing(src => new Medication(src.PatientId, src.Name, src.Dosage, src.Frequency, src.PrescribingDoctor, src.StartDate, src.EndDate));

            TypeAdapterConfig<CreateAllergyCommand, Allergy>
            .NewConfig()
            .ConstructUsing(src => new Allergy(src.PatientId,
            src.Name,
            src.Type,
                src.Severity,
                src.Symptoms,
                src.CommonTriggers,
                src.RecordedDate));

            TypeAdapterConfig<UpdateAllergyCommand, Allergy>
            .NewConfig()
               .ConstructUsing(src => new Allergy(src.PatientId,
               src.Name,
               src.Type,
                src.Severity,
                src.Symptoms,
                src.CommonTriggers,
                src.RecordedDate));

            TypeAdapterConfig<CreateDiagnosisCommand, Diagnosis>
            .NewConfig()
            .ConstructUsing(src => new Diagnosis(src.PatientId, src.Code, src.Description, src.Severity, src.PrescribingDoctor, src.Notes, src.DiagnosedOn));

            TypeAdapterConfig<UpdateDiagnosisCommand, Diagnosis>
            .NewConfig()
            .ConstructUsing(src => new Diagnosis(src.PatientId, src.Code, src.Description, src.Severity, src.PrescribingDoctor, src.Notes, src.DiagnosedOn));


            TypeAdapterConfig<CreateMedicalConditionCommand, MedicalCondition>
           .NewConfig()
           .ConstructUsing(src => new MedicalCondition(src.PatientId, src.Name, src.Description, src.Symptoms, src.Causes, src.Treatments, src.Severity));

            TypeAdapterConfig<UpdateMedicalConditionCommand, MedicalCondition>
            .NewConfig()
            .ConstructUsing(src => new MedicalCondition(src.PatientId, src.Name, src.Description, src.Symptoms, src.Causes, src.Treatments, src.Severity));

            TypeAdapterConfig.GlobalSettings.Compile(); // Compile for performance
        }
    }
}
