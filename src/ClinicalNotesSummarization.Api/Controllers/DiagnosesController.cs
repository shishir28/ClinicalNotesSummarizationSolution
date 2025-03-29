using ClinicalNotesSummarization.Application.Features.Diagnoses.Commands;
using ClinicalNotesSummarization.Application.Features.Diagnoses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicalNotesSummarization.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiagnosesController : Controller
    {
        private readonly IMediator _mediator;

        public DiagnosesController(IMediator mediator) =>
            _mediator = mediator;

        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new Diagnose")]
        [SwaggerResponse(201, "Diagnose created successfully", typeof(Guid))]
        [SwaggerResponse(400, "Invalid request")]
        public async Task<IActionResult> CreateDiagnose([FromBody] CreateDiagnosisCommand command)
        {
            var DiagnoseId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetDiagnoseById), new { id = DiagnoseId }, DiagnoseId);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates an existing Diagnose")]
        [SwaggerResponse(204, "Diagnose updated successfully")]
        [SwaggerResponse(400, "Invalid request")]
        public async Task<IActionResult> UpdateDiagnose(Guid id, [FromBody] UpdateDiagnosisCommand command)
        {
            if (id != command.Id)
                return BadRequest("Diagnose Id mismatch");

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets a Diagnose by Id")]
        [SwaggerResponse(200, "Diagnose retrieved successfully", typeof(GetDiagnosisByIdQueryResult))]
        [SwaggerResponse(404, "Diagnose not found")]
        public async Task<IActionResult> GetDiagnoseById(Guid id)
        {
            var query = new GetDiagnosisIdQuery(id);
            var Diagnose = await _mediator.Send(query);

            if (Diagnose == null)
                return NotFound();

            return Ok(Diagnose);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets all Diagnoses")]
        [SwaggerResponse(200, "Diagnoses retrieved successfully", typeof(List<GetAllDiagnosisQueryResult>))]
        public async Task<IActionResult> GetAllDiagnoses()
        {
            var query = new GetAllDiagnosisQuery();
            var Diagnoses = await _mediator.Send(query);
            return Ok(Diagnoses);
        }

        [HttpGet("patient/{patientId}")]
        [SwaggerOperation(Summary = "Gets all Diagnoses for a patient")]
        [SwaggerResponse(200, "Diagnoses retrieved successfully", typeof(List<GetAllDiagnosisQueryResult>))]
        public async Task<IActionResult> GetAllDiagnoses(Guid patientId)
        {
            var query = new GetAllDiagnosisByPatientIdQuery(patientId);
            var Diagnoses = await _mediator.Send(query);
            return Ok(Diagnoses);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes a Diagnose by Id")]
        [SwaggerResponse(204, "Diagnose deleted successfully")]
        public async Task<IActionResult> DeleteDiagnose(Guid id)
        {
            var command = new DeleteDiagnosisCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
