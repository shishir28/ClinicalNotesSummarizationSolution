using ClinicalNotesSummarization.Application.Features.AI;
using Microsoft.SemanticKernel;

namespace ClinicalNotesSummarization.Orchestration.Services;

public class SemanticSummarizationService : ISummarizationService
{
    private readonly Kernel _kernel;

    public SemanticSummarizationService(Kernel kernel)
    {
        _kernel = kernel;
    }


    public async Task<SummaryResultDto> SummarizePatientAsync(Guid patientId, CancellationToken ct = default)
    {
        // Placeholder: load note text from DB via repository (not implemented here)
        var noteText = $"Clinical note body for {patientId}...";

        var prompt = $"Summarize the following clinical note concisely and list key problems, medications, and follow-up items:\n\n{noteText}";

        //var completion = await _kernel.Text.GenerateAsync(prompt, requestSettings: null, cancellationToken: ct);
        //var text = completion.ToString();
        await Task.CompletedTask; // Simulate async operation

        return new SummaryResultDto
        {
            SummaryText = "TO DO",
            SourcePassages = [noteText],
            GeneratedAt = DateTime.UtcNow
        };
    }
}
