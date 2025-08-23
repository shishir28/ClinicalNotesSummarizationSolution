using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClinicalNotesSummarization.Infrastructure.AI;
using ClinicalNotesSummarization.Infrastructure.AI.Models;
using ClinicalNotesSummarization.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ClinicalNotesSummarization.Orchestration.Services
{
    /// <summary>
    /// Background hosted service that performs a one-time (or incremental) backfill
    /// of embeddings for domain tables and upserts points into Qdrant.
    /// This is a scaffold — wiring and provider implementations are pluggable.
    /// </summary>
    public class EmbeddingBackfillService : BackgroundService
    {
        private readonly ILogger<EmbeddingBackfillService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IQdrantVectorStore _qdrant;

        public EmbeddingBackfillService(ILogger<EmbeddingBackfillService> logger, IServiceScopeFactory scopeFactory, IQdrantVectorStore qdrant)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            _qdrant = qdrant;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("EmbeddingBackfillService started");

            // Ensure qdrant collection exists
            await _qdrant.EnsureCollectionAsync();

            try
            {
                // Run backfill once at startup. For long running incremental backfill,
                // replace with scheduled work or queue-driven processing.
                await RunBackfillAsync(stoppingToken);
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Embedding backfill cancelled");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Embedding backfill failed");
            }
        }

        private async Task RunBackfillAsync(CancellationToken cancellationToken)
        {
            // We'll create a scope to get DB context and scoped services like the embedding provider
            using var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ClinicalNotesDbContext>();
            var embeddingProvider = scope.ServiceProvider.GetRequiredService<IEmbeddingProvider>();

            // process ClinicalNotes
            await ProcessClinicalNotesAsync(db, embeddingProvider, cancellationToken);

            // process other tables similarly
            await ProcessAllergiesAsync(db, embeddingProvider, cancellationToken);
            await ProcessAppointmentsAsync(db, embeddingProvider, cancellationToken);
            await ProcessDiagnosesAsync(db, embeddingProvider, cancellationToken);
            await ProcessMedicalConditionsAsync(db, embeddingProvider, cancellationToken);
            await ProcessMedicationsAsync(db, embeddingProvider, cancellationToken);
        }

        private async Task ProcessClinicalNotesAsync(ClinicalNotesDbContext db, IEmbeddingProvider embeddingProvider, CancellationToken cancellationToken)
        {
            const int batchSize = 50;
            var total = await db.ClinicalNotes.CountAsync(cancellationToken);
            _logger.LogInformation("Processing {Total} clinical notes in batches of {BatchSize}", total, batchSize);

            for (var skip = 0; skip < total; skip += batchSize)
            {
                var batch = await db.ClinicalNotes.OrderBy(n => n.Id).Skip(skip).Take(batchSize).ToListAsync(cancellationToken);
                var points = new List<QdrantPoint>();

                foreach (var note in batch)
                {
                    // Summary: single chunk
                    var summaryText = note.Summary ?? string.Empty;
                    var summaryHash = Sha256Hex(summaryText);
                    if (note.EmbeddingHash != summaryHash)
                    {
                        var embedding = await embeddingProvider.GetEmbeddingsAsync(new[] { summaryText });
                        var vec = embedding.First();
                        var payload = new QdrantPayload
                        {
                            EntityType = "ClinicalNotes",
                            EntityId = note.Id,
                            PatientId = note.PatientId,
                            FieldSource = "Summary",
                            ChunkIndex = 0,
                            TextHash = summaryHash,
                            CreatedAt = DateTimeOffset.UtcNow,
                            SourceSnippet = summaryText.Length > 200 ? summaryText[..200] : summaryText,
                            OriginalLength = summaryText.Length
                        };
                        points.Add(new QdrantPoint($"ClinicalNotes:{note.Id}:Summary:0", vec, payload));

                        // update DB row after upsert (deferred until upsert success)
                        note.EmbeddingHash = summaryHash;
                        note.EmbeddingIndexedAt = DateTimeOffset.UtcNow;
                    }

                    // OriginalText: chunking
                    var original = note.OriginalText ?? string.Empty;
                    var chunks = ChunkText(original);
                    for (var i = 0; i < chunks.Count; i++)
                    {
                        var chunkText = chunks[i];
                        var hash = Sha256Hex(chunkText);
                        // For simplicity we only check top-level note. In production, store per-chunk hashes.
                        if (note.EmbeddingHash != hash)
                        {
                            var embedding = await embeddingProvider.GetEmbeddingsAsync(new[] { chunkText });
                            var vec = embedding.First();
                            var payload = new QdrantPayload
                            {
                                EntityType = "ClinicalNotes",
                                EntityId = note.Id,
                                PatientId = note.PatientId,
                                FieldSource = "OriginalText",
                                ChunkIndex = i,
                                TextHash = hash,
                                CreatedAt = DateTimeOffset.UtcNow,
                                SourceSnippet = chunkText.Length > 200 ? chunkText[..200] : chunkText,
                                OriginalLength = chunkText.Length
                            };
                            points.Add(new QdrantPoint($"ClinicalNotes:{note.Id}:OriginalText:{i}", vec, payload));

                            // update note-level hash/timestamp (approximate)
                            note.EmbeddingHash = hash;
                            note.EmbeddingIndexedAt = DateTimeOffset.UtcNow;
                        }
                    }
                }

                if (points.Any())
                {
                    await _qdrant.UpsertPointsAsync(points);
                    await db.SaveChangesAsync(cancellationToken);
                }
            }
        }
        // Generic processor to reduce duplication. Caller provides:
        // - orderedQuery: the ordered IQueryable for batch reads
        // - getEmbeddingHash / setEmbeddingHash / setEmbeddingIndexedAt: metadata accessors
        // - extractFields: returns field name + text pairs to embed
        // - entityType/getEntityId/getPatientId: payload data
        private async Task ProcessEntityAsync<T>(ClinicalNotesDbContext db, IQueryable<T> orderedQuery,
            Func<T, string?> getEmbeddingHash,
            Action<T, string> setEmbeddingHash,
            Action<T, DateTimeOffset> setEmbeddingIndexedAt,
            Func<T, IEnumerable<(string FieldName, string Text)>> extractFields,
            string entityType,
            Func<T, Guid> getEntityId,
            Func<T, Guid> getPatientId,
            IEmbeddingProvider embeddingProvider,
            CancellationToken cancellationToken)
            where T : class
        {
            const int batchSize = 50;
            var total = await orderedQuery.CountAsync(cancellationToken);
            _logger.LogInformation("Processing {Total} {EntityType} in batches of {BatchSize}", total, entityType, batchSize);

            for (var skip = 0; skip < total; skip += batchSize)
            {
                var batch = await orderedQuery.Skip(skip).Take(batchSize).ToListAsync(cancellationToken);
                var points = new List<QdrantPoint>();

                foreach (var item in batch)
                {
                    foreach (var (FieldName, Text) in extractFields(item))
                    {
                        var text = Text ?? string.Empty;
                        if (string.IsNullOrWhiteSpace(text)) continue;
                        var hash = Sha256Hex(text);
                        if (getEmbeddingHash(item) != hash)
                        {
                            var embedding = await embeddingProvider.GetEmbeddingsAsync(new[] { text });
                            var vec = embedding.First();
                            var payload = new QdrantPayload
                            {
                                EntityType = entityType,
                                EntityId = getEntityId(item),
                                PatientId = getPatientId(item),
                                FieldSource = FieldName,
                                ChunkIndex = 0,
                                TextHash = hash,
                                CreatedAt = DateTimeOffset.UtcNow,
                                SourceSnippet = text.Length > 200 ? text[..200] : text,
                                OriginalLength = text.Length
                            };
                            points.Add(new QdrantPoint($"{entityType}:{getEntityId(item)}:{FieldName}:0", vec, payload));

                            setEmbeddingHash(item, hash);
                            setEmbeddingIndexedAt(item, DateTimeOffset.UtcNow);
                        }
                    }
                }

                if (points.Any())
                {
                    await _qdrant.UpsertPointsAsync(points);
                    await db.SaveChangesAsync(cancellationToken);
                }
            }
        }

        // Typed wrappers that call the generic processor for each domain entity
        private Task ProcessAllergiesAsync(ClinicalNotesDbContext db, IEmbeddingProvider provider, CancellationToken cancellationToken)
            => ProcessEntityAsync<Domain.Entities.Allergy>(
                db,
                db.Allergies.OrderBy(a => a.Id),
                a => a.EmbeddingHash,
                (a, v) => a.EmbeddingHash = v,
                (a, t) => a.EmbeddingIndexedAt = t,
                a => new[] { ("Name", a.Name), ("Type", a.Type), ("Severity", a.Severity), ("Symptoms", a.Symptoms), ("CommonTriggers", a.CommonTriggers) },
                "Allergy",
                a => a.Id,
                a => a.PatientId,
                provider,
                cancellationToken);

        private Task ProcessAppointmentsAsync(ClinicalNotesDbContext db, IEmbeddingProvider provider, CancellationToken cancellationToken)
            => ProcessEntityAsync<Domain.Entities.Appointment>(
                db,
                db.Appointments.OrderBy(a => a.Id),
                a => a.EmbeddingHash,
                (a, v) => a.EmbeddingHash = v,
                (a, t) => a.EmbeddingIndexedAt = t,
                a => new[] { ("DoctorName", a.DoctorName), ("Notes", a.Notes) },
                "Appointment",
                a => a.Id,
                a => a.PatientId,
                provider,
                cancellationToken);

        private Task ProcessDiagnosesAsync(ClinicalNotesDbContext db, IEmbeddingProvider provider, CancellationToken cancellationToken)
            => ProcessEntityAsync<Domain.Entities.Diagnosis>(
                db,
                db.Diagnoses.OrderBy(d => d.Id),
                d => d.EmbeddingHash,
                (d, v) => d.EmbeddingHash = v,
                (d, t) => d.EmbeddingIndexedAt = t,
                d => new[] { ("Code", d.Code), ("Description", d.Description), ("Notes", d.Notes), ("PrescribingDoctor", d.PrescribingDoctor), ("Severity", d.Severity) },
                "Diagnosis",
                d => d.Id,
                d => d.PatientId,
                provider,
                cancellationToken);

        private Task ProcessMedicalConditionsAsync(ClinicalNotesDbContext db, IEmbeddingProvider provider, CancellationToken cancellationToken)
            => ProcessEntityAsync<Domain.Entities.MedicalCondition>(
                db,
                db.MedicalConditions.OrderBy(m => m.Id),
                m => m.EmbeddingHash,
                (m, v) => m.EmbeddingHash = v,
                (m, t) => m.EmbeddingIndexedAt = t,
                m => new[] { ("Name", m.Name), ("Description", m.Description), ("Symptoms", m.Symptoms), ("Causes", m.Causes), ("Treatments", m.Treatments) },
                "MedicalCondition",
                m => m.Id,
                m => m.PatientId,
                provider,
                cancellationToken);

        private Task ProcessMedicationsAsync(ClinicalNotesDbContext db, IEmbeddingProvider provider, CancellationToken cancellationToken)
            => ProcessEntityAsync<Domain.Entities.Medication>(
                db,
                db.Medications.OrderBy(m => m.Id),
                m => m.EmbeddingHash,
                (m, v) => m.EmbeddingHash = v,
                (m, t) => m.EmbeddingIndexedAt = t,
                m => new[] { ("Name", m.Name), ("Dosage", m.Dosage), ("Frequency", m.Frequency), ("PrescribingDoctor", m.PrescribingDoctor) },
                "Medication",
                m => m.Id,
                m => m.PatientId,
                provider,
                cancellationToken);

        // Very naive chunker: split on paragraphs, or fallback to fixed-size window by characters
        private static List<string> ChunkText(string text, int maxChars = 3000)
        {
            if (string.IsNullOrWhiteSpace(text)) return new List<string>();
            var paragraphs = text.Split(new[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var result = new List<string>();
            foreach (var p in paragraphs)
            {
                if (p.Length <= maxChars) result.Add(p);
                else
                {
                    for (var i = 0; i < p.Length; i += maxChars)
                    {
                        var len = Math.Min(maxChars, p.Length - i);
                        result.Add(p.Substring(i, len));
                    }
                }
            }
            if (!result.Any()) result.Add(text.Substring(0, Math.Min(text.Length, maxChars)));
            return result;
        }

        private static string Sha256Hex(string text)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(text ?? string.Empty);
            return Convert.ToHexString(sha.ComputeHash(bytes)).ToLowerInvariant();
        }
    }
}
