namespace ClinicalNotesSummarization.UI.Models
{
    public class MedicalConditionDto
    {
        public Guid Id { get; set; } = default!;
        public Guid PatientId { get; set; }  // Foreign Key
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Symptoms { get; set; } = default!;
        public string Causes { get; set; } = default!;
        public string Treatments { get; set; } = default!;
        public string Severity { get; set; } = default!;
    }
}
