using ClinicalNotesSummarization.Application.Features.MedicalConditions.Commands;
using ClinicalNotesSummarization.Application.Features.MedicalConditions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicalNotesSummarization.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicalConditionsController : Controller
    {
        private readonly IMediator _mediator;

        public MedicalConditionsController(IMediator mediator) =>
            _mediator = mediator;

        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new medicalCondition")]
        [SwaggerResponse(201, "MedicalCondition created successfully", typeof(Guid))]
        [SwaggerResponse(400, "Invalid request")]
        public async Task<IActionResult> CreateMedicalCondition([FromBody] CreateMedicalConditionCommand command)
        {
            var medicalConditionId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetMedicalConditionById), new { id = medicalConditionId }, medicalConditionId);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates an existing medicalCondition")]
        [SwaggerResponse(204, "MedicalCondition updated successfully")]
        [SwaggerResponse(400, "Invalid request")]
        public async Task<IActionResult> UpdateMedicalCondition(Guid id, [FromBody] UpdateMedicalConditionCommand command)
        {
            if (id != command.Id)
                return BadRequest("MedicalCondition Id mismatch");

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets a MedicalCondition by Id")]
        [SwaggerResponse(200, "MedicalCondition retrieved successfully", typeof(GetMedicalConditionByIdQueryResult))]
        [SwaggerResponse(404, "MedicalCondition not found")]
        public async Task<IActionResult> GetMedicalConditionById(Guid id)
        {
            var query = new GetMedicalConditionIdQuery(id);
            var medicalCondition = await _mediator.Send(query);

            if (medicalCondition == null)
                return NotFound();

            return Ok(medicalCondition);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets all medicalConditions")]
        [SwaggerResponse(200, "MedicalConditions retrieved successfully", typeof(List<GetAllMedicalConditionQueryResult>))]
        public async Task<IActionResult> GetAllMedicalConditions()
        {
            var query = new GetAllMedicalConditionQuery();
            var medicalConditions = await _mediator.Send(query);
            return Ok(medicalConditions);
        }

        [HttpGet("patient/{patientId}")]
        [SwaggerOperation(Summary = "Gets all medicalConditions for a patient")]
        [SwaggerResponse(200, "MedicalConditions retrieved successfully", typeof(List<GetAllMedicalConditionQueryResult>))]
        public async Task<IActionResult> GetAllMedicalConditions(Guid patientId)
        {
            var query = new GetAllMedicalConditionByPatientIdQuery(patientId);
            var medicalConditions = await _mediator.Send(query);
            return Ok(medicalConditions);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes a medicalCondition by Id")]
        [SwaggerResponse(204, "MedicalCondition deleted successfully")]
        public async Task<IActionResult> DeleteMedicalCondition(Guid id)
        {
            var command = new DeleteMedicalConditionCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
