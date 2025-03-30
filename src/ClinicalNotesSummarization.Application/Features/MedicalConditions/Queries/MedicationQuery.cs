using MediatR;

namespace ClinicalNotesSummarization.Application.Features.MedicalConditions.Queries
{
    public class GetMedicalConditionIdQuery : IRequest<GetMedicalConditionByIdQueryResult>
    {
        public Guid Id { get; set; } = default!;
        public GetMedicalConditionIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetMedicalConditionByIdQueryResult
    {
        public Guid Id { get; } = default!;
        public Guid PatientId { get; }  // Foreign Key
        public string Name { get; set; }
        public string Description { get; set; }
        public string Symptoms { get; set; }
        public string Causes { get; set; }
        public string Treatments { get; set; }
        public string Severity { get; set; }

        public GetMedicalConditionByIdQueryResult(Guid id,
            Guid patientId,
            string name,
            string description,
            string symptoms,
            string causes,
            string treatments,
            string severity)
        {
            Id = id;
            PatientId = patientId;
            Name = name;
            Description = description;
            Symptoms = symptoms;
            Causes = causes;
            Treatments = treatments;
            Severity = severity;
        }
    }

    public class GetAllMedicalConditionQuery : IRequest<List<GetAllMedicalConditionQueryResult>>
    {
    }

    public class GetAllMedicalConditionQueryResult
    {
        public Guid Id { get; } = default!;
        public Guid PatientId { get; }  // Foreign Key
        public string Name { get; set; }
        public string Description { get; set; }
        public string Symptoms { get; set; }
        public string Causes { get; set; }
        public string Treatments { get; set; }
        public string Severity { get; set; }

        public GetAllMedicalConditionQueryResult(Guid id,
            Guid patientId,
            string name,
            string description,
            string symptoms,
            string causes,
            string treatments,
            string severity)
        {
            Id = id;
            PatientId = patientId;
            Name = name;
            Description = description;
            Symptoms = symptoms;
            Causes = causes;
            Treatments = treatments;
            Severity = severity;
        }
    }


    public class GetAllMedicalConditionByPatientIdQuery : IRequest<List<GetAllMedicalConditionByPatientIdQueryResult>>
    {
        public Guid PatientId { get; set; } = default!;
        public GetAllMedicalConditionByPatientIdQuery(Guid patientId)
        {
            PatientId = patientId;
        }
    }

    public class GetAllMedicalConditionByPatientIdQueryResult
    {
        public Guid Id { get; } = default!;
        public Guid PatientId { get; }  // Foreign Key
        public string Name { get; set; }
        public string Description { get; set; }
        public string Symptoms { get; set; }
        public string Causes { get; set; }
        public string Treatments { get; set; }
        public string Severity { get; set; }

        public GetAllMedicalConditionByPatientIdQueryResult(Guid id,
            Guid patientId,
            string name,
            string description,
            string symptoms,
            string causes,
            string treatments,
            string severity)
        {
            Id = id;
            PatientId = patientId;
            Name = name;
            Description = description;
            Symptoms = symptoms;
            Causes = causes;
            Treatments = treatments;
            Severity = severity;
        }
    }
}
