namespace ClinicalNotesSummarization.UI.Models
{
    public class AllergyDto
    {
        public Guid Id { get; set; } = default!;
        public Guid PatientId { get; set; }  // Foreign Key
        public string Name { get; set; }
        public string Type { get; set; }

        public string Severity { get; set; }  // Enum: Mild, Moderate, Severe
        public string Symptoms { get; set; }
        public string CommonTriggers { get; set; }
        public DateTime? RecordedDate { get; set; }
    }
}
