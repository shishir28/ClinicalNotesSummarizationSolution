using MediatR;

namespace ClinicalNotesSummarization.Application.Features.Allergies.Queries
{
    public class GetAllergyIdQuery : IRequest<GetAllergyByIdQueryResult>
    {
        public Guid Id { get; set; } = default!;
        public GetAllergyIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetAllergyByIdQueryResult
    {
        public Guid Id { get; } = default!;
        public Guid PatientId { get; }  // Foreign Key
        public string Name { get; set; }
        public string Type { get; set; }

        public string Severity { get; set; }  // Enum: Mild, Moderate, Severe
        public string Symptoms { get; set; }
        public string CommonTriggers { get; set; }
        public DateTimeOffset? RecordedDate { get; }
        public GetAllergyByIdQueryResult(Guid id,
            Guid patientId,
            string name,
            string type,
            string severity,
            string symptoms,
            string commonTriggers,            
            DateTimeOffset? recordedDate)
        {
            Id = id;
            PatientId = patientId;
            Name = name;
            Type = type;
            Severity = severity;
            Symptoms = symptoms;
            CommonTriggers = commonTriggers;
            RecordedDate = recordedDate;
        }
    }

    public class GetAllAllergyQuery : IRequest<List<GetAllAllergyQueryResult>>
    {
    }

    public class GetAllAllergyQueryResult
    {
        public Guid Id { get; } = default!;
        public Guid PatientId { get; }  // Foreign Key
        public string Name { get; set; }
        public string Type { get; set; }

        public string Severity { get; set; }  // Enum: Mild, Moderate, Severe
        public string Symptoms { get; set; }
        public string CommonTriggers { get; set; }
        public DateTimeOffset? RecordedDate { get; }
        public GetAllAllergyQueryResult(Guid id,
            Guid patientId,
            string name,
            string type,
            string severity,
            string symptoms,
            string commonTriggers,
            DateTimeOffset? recordedDate)
        {
            Id = id;
            PatientId = patientId;
            Name = name;
            Type = type;
            Severity = severity;
            Symptoms = symptoms;
            CommonTriggers = commonTriggers;
            RecordedDate = recordedDate;
        }
    }

    public class GetAllAllergyByPatientIdQuery : IRequest<List<GetAllAllergyByPatientIdQueryResult>>
    {
        public Guid PatientId { get; set; } = default!;
        public GetAllAllergyByPatientIdQuery(Guid patientId)
        {
            PatientId = patientId;
        }
    }

    public class GetAllAllergyByPatientIdQueryResult
    {
        public Guid Id { get; } = default!;
        public Guid PatientId { get; }  // Foreign Key
        public string Name { get; set; }
        public string Type { get; set; }

        public string Severity { get; set; }  // Enum: Mild, Moderate, Severe
        public string Symptoms { get; set; }
        public string CommonTriggers { get; set; }
        public DateTimeOffset? RecordedDate { get; }
        public GetAllAllergyByPatientIdQueryResult(Guid id,
            Guid patientId,
            string name,
            string type,
            string severity,
            string symptoms,
            string commonTriggers,
            DateTimeOffset? recordedDate)
        {
            Id = id;
            PatientId = patientId;
            Name = name;
            Type = type;
            Severity = severity;
            Symptoms = symptoms;
            CommonTriggers = commonTriggers;
            RecordedDate = recordedDate;
        }
    }

}
