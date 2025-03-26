namespace ClinicalNotesSummarization.UI.Models
{
    public class MedicationDto
    {
        public Guid Id { get; set; } = default!;
        public Guid PatientId { get; set; }  // Foreign Key
        public string Name { get; set; } = default!;
        public string Dosage { get; set; } = default!;
        public string Frequency { get; set; } = default!;
        public string PrescribingDoctor { get; set; } = default!;
        public DateTime? StartDate { get; set; } = default!;
        public DateTime? EndDate { get; set; } = default!;
    }
}
