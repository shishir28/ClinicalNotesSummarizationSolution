using System.Text.Json;

namespace ClinicalNotesSummarization.Orchestration.Plugins;

public interface IPatientPlugin
{
    // Return structured patient JSON for the given patientId
    Task<JsonElement> GetPatientAsync(Guid patientId, CancellationToken cancellationToken = default);

    // // Return medications array JSON
    // Task<JsonElement> GetMedicationsAsync(Guid patientId, CancellationToken cancellationToken = default);

    // // Return conditions array JSON
    // Task<JsonElement> GetConditionsAsync(Guid patientId, CancellationToken cancellationToken = default);

    // // Return diagnoses array JSON
    // Task<JsonElement> GetDiagnosesAsync(Guid patientId, CancellationToken cancellationToken = default);

    // // Return allergies array JSON
    // Task<JsonElement> GetAllergiesAsync(Guid patientId, CancellationToken cancellationToken = default);
}
