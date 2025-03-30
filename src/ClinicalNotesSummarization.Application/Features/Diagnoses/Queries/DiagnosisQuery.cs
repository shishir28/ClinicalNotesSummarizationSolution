using MediatR;

namespace ClinicalNotesSummarization.Application.Features.Diagnoses.Queries
{
    public class GetDiagnosisIdQuery : IRequest<GetDiagnosisByIdQueryResult>
    {
        public Guid Id { get; set; } = default!;
        public GetDiagnosisIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetDiagnosisByIdQueryResult
    {
        public Guid Id { get; } = default!;
        public Guid PatientId { get; }  // Foreign Key
        public string Code { get; private set; } // ICD-10 or other medical code
        public string Description { get; private set; }
        public string Severity { get; set; }
        public string PrescribingDoctor { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset? DiagnosedOn { get; }

        public GetDiagnosisByIdQueryResult(Guid id,
            Guid patientId,
            string code,
            string description,
            string severity,
            string prescribingDoctor,
            string notes,
            DateTimeOffset? diagnosedOn)
        {
            Id = id;
            PatientId = patientId;
            Code = code;
            Description = description;
            Severity = severity;
            PrescribingDoctor = prescribingDoctor;
            Notes = notes;
            DiagnosedOn = diagnosedOn;
        }
    }

    public class GetAllDiagnosisQuery : IRequest<List<GetAllDiagnosisQueryResult>>
    {
    }

    public class GetAllDiagnosisQueryResult
    {
        public Guid Id { get; } = default!;
        public Guid PatientId { get; }  // Foreign Key
        public string Code { get; private set; } // ICD-10 or other medical code
        public string Description { get; private set; }
        public string Severity { get; set; }
        public string PrescribingDoctor { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset? DiagnosedOn { get; }

        public GetAllDiagnosisQueryResult(Guid id,
            Guid patientId,
            string code,
            string description,
            string severity,
            string prescribingDoctor,
            string notes,
            DateTimeOffset? diagnosedOn)
        {
            Id = id;
            PatientId = patientId;
            Code = code;
            Description = description;
            Severity = severity;
            PrescribingDoctor = prescribingDoctor;
            Notes = notes;
            DiagnosedOn = diagnosedOn;
        }
    }

    public class GetAllDiagnosisByPatientIdQuery : IRequest<List<GetAllDiagnosisByPatientIdQueryResult>>
    {
        public Guid PatientId { get; set; } = default!;
        public GetAllDiagnosisByPatientIdQuery(Guid patientId)
        {
            PatientId = patientId;
        }
    }

    public class GetAllDiagnosisByPatientIdQueryResult
    {
        public Guid Id { get; } = default!;
        public Guid PatientId { get; }  // Foreign Key
        public string Code { get; private set; } // ICD-10 or other medical code
        public string Description { get; private set; }
        public string Severity { get; set; }
        public string PrescribingDoctor { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset? DiagnosedOn { get; }

        public GetAllDiagnosisByPatientIdQueryResult(Guid id,
            Guid patientId,
            string code,
            string description,
            string severity,
            string prescribingDoctor,
            string notes,
            DateTimeOffset? diagnosedOn)
        {
            Id = id;
            PatientId = patientId;
            Code = code;
            Description = description;
            Severity = severity;
            PrescribingDoctor = prescribingDoctor;
            Notes = notes;
            DiagnosedOn = diagnosedOn;
        }
    }
}
