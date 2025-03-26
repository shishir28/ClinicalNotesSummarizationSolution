using ClinicalNotesSummarization.Application.Features.Medications.Commands;
using ClinicalNotesSummarization.Application.Features.Medications.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicalNotesSummarization.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicationsController : Controller
    {
        private readonly IMediator _mediator;

        public MedicationsController(IMediator mediator) =>
            _mediator = mediator;

        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new medication")]
        [SwaggerResponse(201, "Medication created successfully", typeof(Guid))]
        [SwaggerResponse(400, "Invalid request")]
        public async Task<IActionResult> CreateMedication([FromBody] CreateMedicationCommand command)
        {
            var medicationId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetMedicationById), new { id = medicationId }, medicationId);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates an existing medication")]
        [SwaggerResponse(204, "Medication updated successfully")]
        [SwaggerResponse(400, "Invalid request")]
        public async Task<IActionResult> UpdateMedication(Guid id, [FromBody] UpdateMedicationCommand command)
        {
            if (id != command.Id)
                return BadRequest("Medication Id mismatch");

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets a Medication by Id")]
        [SwaggerResponse(200, "Medication retrieved successfully", typeof(GetMedicationByIdQueryResult))]
        [SwaggerResponse(404, "Medication not found")]
        public async Task<IActionResult> GetMedicationById(Guid id)
        {
            var query = new GetMedicationIdQuery(id);
            var medication = await _mediator.Send(query);

            if (medication == null)
                return NotFound();

            return Ok(medication);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets all medications")]
        [SwaggerResponse(200, "Medications retrieved successfully", typeof(List<GetAllMedicationQueryResult>))]
        public async Task<IActionResult> GetAllMedications()
        {
            var query = new GetAllMedicationQuery();
            var medications = await _mediator.Send(query);
            return Ok(medications);
        }

        [HttpGet("patient/{patientId}")]
        [SwaggerOperation(Summary = "Gets all medications for a patient")]
        [SwaggerResponse(200, "Medications retrieved successfully", typeof(List<GetAllMedicationQueryResult>))]
        public async Task<IActionResult> GetAllMedications(Guid patientId)
        {
            var query = new GetAllMedicationByPatientIdQuery(patientId);
            var medications = await _mediator.Send(query);
            return Ok(medications);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes a medication by Id")]
        [SwaggerResponse(204, "Medication deleted successfully")]
        public async Task<IActionResult> DeleteMedication(Guid id)
        {
            var command = new DeleteMedicationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
