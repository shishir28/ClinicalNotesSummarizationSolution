using System.Text;
using System.Text.Json;
using ClinicalNotesSummarization.Application.Features.AI;
using ClinicalNotesSummarization.Orchestration.Plugins;

namespace ClinicalNotesSummarization.Orchestration.Services;

public class SemanticSummarizationService : ISummarizationService
{
    private readonly IPatientPlugin _patientPlugin;
    private readonly ITextGenerator _textGenerator;

    public SemanticSummarizationService(IPatientPlugin patientPlugin, ITextGenerator textGenerator)
    {
        _patientPlugin = patientPlugin;
        _textGenerator = textGenerator;
    }

    public async Task<SummaryResultDto> SummarizePatientAsync(Guid patientId, CancellationToken ct = default)
    {
        // 1) Fetch structured data from plugins
        var patientJson = await _patientPlugin.GetPatientAsync(patientId, ct);
        var medsJson = await _patientPlugin.GetMedicationsAsync(patientId, ct);
        var condJson = await _patientPlugin.GetConditionsAsync(patientId, ct);
        var diagJson = await _patientPlugin.GetDiagnosesAsync(patientId, ct);
        var allergyJson = await _patientPlugin.GetAllergiesAsync(patientId, ct);

        // 2) Load prompt template
        string promptTemplate = null!;
        var relativePath = Path.Combine("Prompts", "Summarization", "summaryPrompt.txt");
        if (File.Exists(relativePath))
        {
            promptTemplate = await File.ReadAllTextAsync(relativePath, ct);
        }
        else
        {
            var alt = Path.Combine(AppContext.BaseDirectory, "Prompts", "Summarization", "summaryPrompt.txt");
            if (File.Exists(alt)) promptTemplate = await File.ReadAllTextAsync(alt, ct);
        }

        if (string.IsNullOrWhiteSpace(promptTemplate))
        {
            // fallback simple prompt
            promptTemplate = "SYSTEM: You are a clinical summarizer. INPUT:\n- patientId: {{patientId}}\n- patient: {{patient}}\n- medications: {{medications}}\n- conditions: {{conditions}}\n- diagnoses: {{diagnoses}}\n- allergies: {{allergies}}\nINSTRUCTIONS: Summarize into JSON with summaryText and sources.";
        }

        // 3) Populate template placeholders with JSON text
        string prompt = promptTemplate
            .Replace("{{patientId}}", patientId.ToString())
            .Replace("{{patient}}", patientJson.GetRawText())
            .Replace("{{medications}}", medsJson.GetRawText())
            .Replace("{{conditions}}", condJson.GetRawText())
            .Replace("{{diagnoses}}", diagJson.GetRawText())
            .Replace("{{allergies}}", allergyJson.GetRawText())
            ;

        // 4) Call the text generator (this may be replaced with Semantic Kernel invocation later)
        var generated = await _textGenerator.GenerateAsync(prompt, ct);

        // 5) Try to parse the generated text as JSON per the prompt's OUTPUT spec
        if (!TryExtractJson(generated, out var root) || root.ValueKind != JsonValueKind.Object)
        {
            // Fallback: return empty result with error message
            var dto = new SummaryResultDto
            {
                SummaryText = root.GetProperty("summaryText").GetString() ?? string.Empty,
                // GeneratedAt = DateTime.UtcNow
            };

            // if (root.TryGetProperty("sources", out var sources) && sources.ValueKind == JsonValueKind.Array)
            //     dto.SourcePassages = [.. sources.EnumerateArray().Select(x => x.GetString() ?? string.Empty).Where(x => !string.IsNullOrEmpty(x))];
            return dto;
        }
        return new SummaryResultDto
        {
            SummaryText = FormatSummaryJson(root.GetRawText()),
        };
    }

    private static bool TryExtractJson(string modelOutput, out JsonElement root)
    {
        root = default;
        try
        {
            using var doc = JsonDocument.Parse(modelOutput);
            root = doc.RootElement.Clone(); // clone to survive doc disposal
            return true;
        }
        catch (JsonException)
        {
            return false;
        }
    }

    public static string FormatSummaryJson(string json)
    {
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        string header = root.TryGetProperty("patientHeader", out var h) ? h.GetString() ?? "" : "";
        var sb = new StringBuilder();
        sb.AppendLine($"Patient Header: {header}");
        sb.AppendLine();

        sb.AppendLine("Sources:");
        if (root.TryGetProperty("sources", out var sources) && sources.ValueKind == JsonValueKind.Array && sources.EnumerateArray().Any())
        {
            foreach (var s in sources.EnumerateArray())
            {
                var val = s.GetString() ?? "";
                sb.AppendLine($"- {val}");
            }
        }
        else
        {
            sb.AppendLine("- (none)");
        }
        sb.AppendLine();

        sb.AppendLine("Summary Text:");
        if (root.TryGetProperty("summaryText", out var summary))
        {
            // Wrap or indent if you want; for now preserve as-is.
            sb.AppendLine(summary.GetString() ?? "");
        }

        return sb.ToString();
    }
}
