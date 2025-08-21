using System.Text.Json;
using System.Linq;
using ClinicalNotesSummarization.Domain.Repositories;
using ClinicalNotesSummarization.Domain.Entities;
using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace ClinicalNotesSummarization.Orchestration.Plugins;

public class PatientRepositoryPlugin : IPatientPlugin
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMedicationRepository _medicationRepository;
    private readonly IAllergyRepository _allergy_repository;
    private readonly IDiagnosisRepository _diagnosis_repository;
    private readonly IMedicalConditionRepository _condition_repository;

    public PatientRepositoryPlugin(IPatientRepository patientRepository,
        IMedicationRepository medicationRepository,
        IAllergyRepository allergyRepository,
        IDiagnosisRepository diagnosisRepository,
        IMedicalConditionRepository conditionRepository)
    {
        _patientRepository = patientRepository;
        _medicationRepository = medicationRepository;
        _allergy_repository = allergyRepository;
        _diagnosis_repository = diagnosisRepository;
        _condition_repository = conditionRepository;
    }

    [KernelFunction]
    [Description("Fetches structured patient data as JSON for the specified patient ID.")]
    public async Task<JsonElement> GetPatientAsync(Guid patientId, CancellationToken cancellationToken = default)
    {
        var patient = await _patientRepository.GetByIdAsync(patientId);
        if (patient == null) return EmptyJson();
        var json = JsonSerializer.SerializeToElement(new
        {
            id = patient.Id,
            firstName = patient.FirstName,
            lastName = patient.LastName,
            dob = patient.DateOfBirth,
            gender = patient.Gender.ToString(),
            phone = patient.PhoneNumber,
            email = patient.Email,
            address = patient.Address
        });
        return json;
    }

    public async Task<JsonElement> GetMedicationsAsync(Guid patientId, CancellationToken cancellationToken = default)
    {
        var meds = await _medicationRepository.GetByPatientIdAsync(patientId);
        var json = JsonSerializer.SerializeToElement(meds.Select(m => new {
            name = m.Name,
            dosage = m.Dosage,
            frequency = m.Frequency,
            prescribingDoctor = m.PrescribingDoctor,
            startDate = m.StartDate,
            endDate = m.EndDate
        }));
        return json;
    }

    public async Task<JsonElement> GetConditionsAsync(Guid patientId, CancellationToken cancellationToken = default)
    {
        var conds = await _condition_repository.GetByPatientIdAsync(patientId);
        var json = JsonSerializer.SerializeToElement(conds.Select(c => new {
            name = c.Name,
            description = c.Description,
            severity = c.Severity,
            treatments = c.Treatments
        }));
        return json;
    }

    public async Task<JsonElement> GetDiagnosesAsync(Guid patientId, CancellationToken cancellationToken = default)
    {
        var diags = await _diagnosis_repository.GetByPatientIdAsync(patientId);
        var json = JsonSerializer.SerializeToElement(diags.Select(d => new {
            code = d.Code,
            description = d.Description,
            severity = d.Severity,
            prescribingDoctor = d.PrescribingDoctor,
            diagnosedOn = d.DiagnosedOn
        }));
        return json;
    }

    public async Task<JsonElement> GetAllergiesAsync(Guid patientId, CancellationToken cancellationToken = default)
    {
        var alls = await _allergy_repository.GetByPatientIdAsync(patientId);
        var json = JsonSerializer.SerializeToElement(alls.Select(a => new {
            name = a.Name,
            type = a.Type,
            severity = a.Severity,
            symptoms = a.Symptoms
        }));
        return json;
    }

    private static JsonElement EmptyJson() => JsonDocument.Parse("{}").RootElement.Clone();
}
