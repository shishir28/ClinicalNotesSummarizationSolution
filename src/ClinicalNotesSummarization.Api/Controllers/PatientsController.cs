using ClinicalNotesSummarization.Application.Features.Allergies.Queries;
using ClinicalNotesSummarization.Application.Features.Diagnoses.Queries;
using ClinicalNotesSummarization.Application.Features.MedicalConditions.Queries;
using ClinicalNotesSummarization.Application.Features.Medications.Queries;
using ClinicalNotesSummarization.Application.Features.Patients.Commands;
using ClinicalNotesSummarization.Application.Features.Patients.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicalNotesSummarization.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator) =>
            _mediator = mediator;

        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new patient")]
        [SwaggerResponse(201, "Patient created successfully", typeof(Guid))]
        [SwaggerResponse(400, "Invalid request")]
        public async Task<IActionResult> CreatePatient([FromBody] CreatePatientCommand command)
        {
            var patientId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetPatientById), new { id = patientId }, patientId);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates an existing patient")]
        [SwaggerResponse(204, "Patient updated successfully")]
        [SwaggerResponse(400, "Invalid request")]
        public async Task<IActionResult> UpdatePatient(Guid id, [FromBody] UpdatePatientCommand command)
        {
            if (id != command.Id)
                return BadRequest("Patient ID mismatch");

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets a patient by Id")]
        [SwaggerResponse(200, "Patient retrieved successfully", typeof(GetPatientByIdQueryResult))]
        [SwaggerResponse(404, "Patient not found")]
        public async Task<IActionResult> GetPatientById(Guid id)
        {
            var query = new GetPatientByIdQuery(id);
            var patient = await _mediator.Send(query);

            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets all patients")]
        [SwaggerResponse(200, "Patients retrieved successfully", typeof(List<GetAllPatientsQueryResult>))]
        public async Task<IActionResult> GetAllPatients()
        {
            var query = new GetAllPatientsQuery();
            var patients = await _mediator.Send(query);
            return Ok(patients);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes a patient by Id")]
        [SwaggerResponse(204, "Patient deleted successfully")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            var command = new DeletePatientCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpGet("{id}/medications")]
        [SwaggerOperation(Summary = "Gets a medication by patient by Id")]
        [SwaggerResponse(200, "Medications retrieved successfully", typeof(GetAllMedicationByPatientIdQuery))]
        [SwaggerResponse(404, "Medications not found")]
        public async Task<IActionResult> GetMedicationsPatientById(Guid id)
        {
            var query = new GetAllMedicationByPatientIdQuery(id);
            var medications = await _mediator.Send(query);

            if (medications == null)
                return NotFound();

            return Ok(medications);
        }

        [HttpGet("{id}/allergies")]
        [SwaggerOperation(Summary = "Gets a allergies by patient by Id")]
        [SwaggerResponse(200, "Allergies retrieved successfully", typeof(GetAllAllergyByPatientIdQuery))]
        [SwaggerResponse(404, "Allergies not found")]
        public async Task<IActionResult> GetAllergiesPatientById(Guid id)
        {
            var query = new GetAllAllergyByPatientIdQuery(id);
            var allergies = await _mediator.Send(query);

            if (allergies == null)
                return NotFound();

            return Ok(allergies);
        }

        [HttpGet("{id}/diagnoses")]
        [SwaggerOperation(Summary = "Gets a diagnoses by patient by Id")]
        [SwaggerResponse(200, "Diagnoses retrieved successfully", typeof(GetAllDiagnosisByPatientIdQuery))]
        [SwaggerResponse(404, "Diagnoses not found")]
        public async Task<IActionResult> GetDiagnosesPatientById(Guid id)
        {
            var query = new GetAllDiagnosisByPatientIdQuery(id);
            var diagnoses = await _mediator.Send(query);

            if (diagnoses == null)
                return NotFound();

            return Ok(diagnoses);
        }

        [HttpGet("{id}/medicalconditions")]
        [SwaggerOperation(Summary = "Gets a medical conditions by patient by Id")]
        [SwaggerResponse(200, "Medical conditions retrieved successfully", typeof(GetAllDiagnosisByPatientIdQuery))]
        [SwaggerResponse(404, "< m>edical conditions not found")]
        public async Task<IActionResult> GetMedicalConditionsPatientById(Guid id)
        {
            var query = new GetAllMedicalConditionByPatientIdQuery(id);
            var medicalConditions = await _mediator.Send(query);

            if (medicalConditions == null)
                return NotFound();

            return Ok(medicalConditions);
        }
    }
}
