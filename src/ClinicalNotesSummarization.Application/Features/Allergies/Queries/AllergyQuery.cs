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
        public string Allergen { get; }
        public string Reaction { get; }
        public string Severity { get; }
        public DateTimeOffset? RecordedDate { get; }

        public GetAllergyByIdQueryResult(Guid id,
            Guid patientId,
            string allergen,
            string reaction,
            string severity,
            DateTimeOffset? recordedDate)
        {
            Id = id;
            PatientId = patientId;
            Allergen = allergen;
            Reaction = reaction;
            Severity = severity;
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
        public string Allergen { get; }
        public string Reaction { get; }
        public string Severity { get; }
        public DateTimeOffset? RecordedDate { get; }
        public GetAllAllergyQueryResult(Guid id,
            Guid patientId,
            string allergen,
            string reaction,
            string severity,
            DateTimeOffset? recordedDate)
        {
            Id = id;
            PatientId = patientId;
            Allergen = allergen;
            Reaction = reaction;
            Severity = severity;
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
        public string Allergen { get; }
        public string Reaction { get; }
        public string Severity { get; }
        public DateTimeOffset? RecordedDate { get; }
        public GetAllAllergyByPatientIdQueryResult(Guid id,
            Guid patientId,
            string allergen,
            string reaction,
            string severity,
            DateTimeOffset? recordedDate)
        {
            Id = id;
            PatientId = patientId;
            Allergen = allergen;
            Reaction = reaction;
            Severity = severity;
            RecordedDate = recordedDate;
        }
    }

}
