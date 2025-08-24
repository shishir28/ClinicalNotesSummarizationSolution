using ClinicalNotesSummarization.Application.Features.AI;
using ClinicalNotesSummarization.Infrastructure.AI;
using ClinicalNotesSummarization.Orchestration.Plugins;

namespace ClinicalNotesSummarization.Orchestration.Services;

public class PatientChatService : IPatientChatService
{
    private readonly IQdrantVectorStore _qdrant;
    private readonly IEmbeddingProvider _embeddings;
    private readonly IPatientPlugin _patientPlugin;
    private readonly ITextGenerator _textGenerator;

    public PatientChatService(IQdrantVectorStore qdrant, IEmbeddingProvider embeddings, IPatientPlugin patientPlugin, ITextGenerator textGenerator)
    {
        _qdrant = qdrant;
        _embeddings = embeddings;
        _patientPlugin = patientPlugin;
        _textGenerator = textGenerator;
    }

    public async Task<PatientChatResponseDto> SendPatientMessageAsync(Guid patientId, PatientChatRequestDto request, CancellationToken cancellationToken = default)
    {
        var embeds = await _embeddings.GetEmbeddingsAsync(new[] { request.Message });
        var vector = embeds.FirstOrDefault();
        if (vector == null) return new PatientChatResponseDto { ConversationId = patientId, Reply = "[error: embedding failure]" };

        var points = await _qdrant.SearchPointsAsync(vector, topK: request.TopKDocs);
        var relevant = points.Where(p => p.Payload.PatientId == patientId).Take(request.TopKDocs).ToList();

        var snippets = relevant.Select(p => new { Source = p.Payload.SourceSnippet ?? string.Empty, Meta = p.Payload }).ToList();

        var sb = new System.Text.StringBuilder();
        sb.AppendLine("SYSTEM: You are a clinical assistant. Use only the sources provided to answer. If unsure, say you don't know.");
        sb.AppendLine();
        sb.AppendLine("SOURCES:");
        for (int i = 0; i < snippets.Count; i++)
        {
            var s = snippets[i];
            sb.AppendLine($"[{i}] {s.Meta.EntityType}.{s.Meta.FieldSource} (chunk:{s.Meta.ChunkIndex}): {s.Source}");
        }
        sb.AppendLine();
        sb.AppendLine("USER:");
        sb.AppendLine(request.Message);
        sb.AppendLine();
        sb.AppendLine("INSTRUCTIONS: Answer concisely and list the source indices you used.");

        var prompt = sb.ToString();
        var reply = await _textGenerator.GenerateAsync(prompt, cancellationToken);

        return new PatientChatResponseDto { ConversationId = patientId, Reply = reply, Sources = snippets.Select((s, i) => new { Index = i, s.Meta.EntityType, s.Meta.FieldSource }) };
    }

    public async Task<object> SearchPatientsAsync(PatientChatRequestDto request, CancellationToken cancellationToken = default)
    {
        var embeds = await _embeddings.GetEmbeddingsAsync(new[] { request.Message });
        var vector = embeds.FirstOrDefault();
        if (vector == null) return Array.Empty<object>();

        var points = await _qdrant.SearchAsync(vector, topK: 200);
        var groups = points
            .Where(p => p.Payload.ContainsKey("patientId"))
            .GroupBy(p => p.Payload["patientId"]?.ToString() ?? string.Empty)
            .Select(g => new { PatientId = g.Key, Score = g.Sum(x => x.Score), Hits = g.Count(), Top = g.OrderByDescending(x => x.Score).Take(3).ToList() })
            .OrderByDescending(x => x.Score)
            .Take(request.TopKPatients)
            .ToList();

        var results = new List<object>();
        foreach (var g in groups)
        {
            if (!Guid.TryParse(g.PatientId, out var pid)) continue;
            var patientJson = await _patientPlugin.GetPatientAsync(pid, cancellationToken);
            results.Add(new { PatientId = pid, Score = g.Score, Patient = patientJson, TopHits = g.Top.Select(h => new { h.PointId, h.Score, h.Payload }) });
        }

        return results;
    }
}
    