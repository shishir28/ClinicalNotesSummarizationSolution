namespace ClinicalNotesSummarization.UI.Models
{
    public class DiagnosisDto
    {
        public Guid Id { get; set; } = default!;
        public Guid PatientId { get; set; }  // Foreign Key
        public string Code { get;  set; } // ICD-10 or other medical code
        public string Description { get;  set; }
        public string Severity { get; set; }
        public string PrescribingDoctor { get; set; }
        public string Notes { get; set; }

        public DateTime? DiagnosedOn { get;  set; }
    }
}
