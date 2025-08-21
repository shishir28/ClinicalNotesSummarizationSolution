namespace ClinicalNotesSummarization.Application.Features.AI;

public interface ISummarizationService
{
    Task<SummaryResultDto> SummarizePatientAsync(Guid patientId, CancellationToken ct = default);
}

public class SummaryResultDto
{
    public string SummaryText { get; set; } = string.Empty;
    // public IEnumerable<string> SourcePassages { get; set; } = [];
    // public DateTime GeneratedAt { get; set; }
}
