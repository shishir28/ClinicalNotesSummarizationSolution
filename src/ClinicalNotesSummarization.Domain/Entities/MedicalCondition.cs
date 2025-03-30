using ClinicalNotesSummarization.SharedKernel.Entities;

namespace ClinicalNotesSummarization.Domain.Entities
{
    public class MedicalCondition : BaseEntity
    {
        public Guid PatientId { get; set; }  // Foreign Key
        public string Name { get; set; }
        public string Description { get; set; }
        public string Symptoms { get; set; }
        public string Causes { get; set; }
        public string Treatments { get; set; }
        public string Severity { get; set; }

        // Navigation Property
        public Patient Patient { get; set; }

        public MedicalCondition(Guid patientId,
        string name,
        string description,
        string symptoms,
        string causes,
        string treatments,
        string severity)
        {
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
