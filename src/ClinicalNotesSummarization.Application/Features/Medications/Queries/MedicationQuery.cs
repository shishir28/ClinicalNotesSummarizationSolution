using MediatR;

namespace ClinicalNotesSummarization.Application.Features.Medications.Queries
{
    public class GetMedicationIdQuery : IRequest<GetMedicationByIdQueryResult>
    {
        public Guid Id { get; set; } = default!;
        public GetMedicationIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetMedicationByIdQueryResult
    {
        public Guid Id { get; } = default!;
        public Guid PatientId { get; }  // Foreign Key
        public string Name { get; }
        public string Dosage { get; }
        public string Frequency { get; }
        public string PrescribingDoctor { get; }
        public DateTimeOffset StartDate { get; }
        public DateTimeOffset? EndDate { get; }

        public GetMedicationByIdQueryResult(Guid id,
            Guid patientId,
            string name,
            string dosage,
            string frequency,
            string prescribingDoctor,
            DateTimeOffset startDate,
            DateTimeOffset? endDate)
        {
            Id = id;
            PatientId = patientId;
            Name = name;
            Dosage = dosage;
            Frequency = frequency;
            PrescribingDoctor = prescribingDoctor;
            StartDate = startDate;
            EndDate = endDate;
        }
    }

    public class GetAllMedicationQuery : IRequest<List<GetAllMedicationQueryResult>>
    {
    }

    public class GetAllMedicationQueryResult
    {
        public Guid Id { get; } = default!;
        public Guid PatientId { get; }  // Foreign Key
        public string Name { get; }
        public string Dosage { get; }
        public string Frequency { get; }
        public string PrescribingDoctor { get; }
        public DateTimeOffset StartDate { get; }
        public DateTimeOffset? EndDate { get; }

        public GetAllMedicationQueryResult(Guid id,
            Guid patientId,
            string name,
            string dosage,
            string frequency,
            string prescribingDoctor,
            DateTimeOffset startDate,
            DateTimeOffset? endDate)
        {
            Id = id;
            PatientId = patientId;
            Name = name;
            Dosage = dosage;
            Frequency = frequency;
            PrescribingDoctor = prescribingDoctor;
            StartDate = startDate;
            EndDate = endDate;
        }
    }


    public class GetAllMedicationByPatientIdQuery : IRequest<List<GetAllMedicationByPatientIdQueryResult>>
    {
        public Guid PatientId { get; set; } = default!;
        public GetAllMedicationByPatientIdQuery(Guid patientId)
        {
            PatientId = patientId;
        }
    }

    public class GetAllMedicationByPatientIdQueryResult
    {
        public Guid Id { get; } = default!;
        public Guid PatientId { get; }  // Foreign Key
        public string Name { get; }
        public string Dosage { get; }
        public string Frequency { get; }
        public string PrescribingDoctor { get; }
        public DateTimeOffset StartDate { get; }
        public DateTimeOffset? EndDate { get; }

        public GetAllMedicationByPatientIdQueryResult(Guid id,
            Guid patientId,
            string name,
            string dosage,
            string frequency,
            string prescribingDoctor,
            DateTimeOffset startDate,
            DateTimeOffset? endDate)
        {
            Id = id;
            PatientId = patientId;
            Name = name;
            Dosage = dosage;
            Frequency = frequency;
            PrescribingDoctor = prescribingDoctor;
            StartDate = startDate;
            EndDate = endDate;
        }
    }

}
