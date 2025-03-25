using ClinicalNotesSummarization.Application.Features.Patients.Commands;
using ClinicalNotesSummarization.Application.Features.Patients.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicalNotesSummarization.Api.Controllers
{
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
            [SwaggerOperation(Summary = "Gets a patient by ID")]
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
            [SwaggerOperation(Summary = "Deletes a patient by ID")]
            [SwaggerResponse(204, "Patient deleted successfully")]
            public async Task<IActionResult> DeletePatient(Guid id)
            {
                var command = new DeletePatientCommand { Id = id };
                await _mediator.Send(command);
                return NoContent();
            }
        }
    }
}
