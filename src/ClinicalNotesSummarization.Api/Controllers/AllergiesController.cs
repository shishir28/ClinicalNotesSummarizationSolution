using ClinicalNotesSummarization.Application.Features.Allergies.Commands;
using ClinicalNotesSummarization.Application.Features.Allergies.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicalNotesSummarization.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AllergiesController : Controller
    {
        private readonly IMediator _mediator;

        public AllergiesController(IMediator mediator) =>
            _mediator = mediator;

        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new allergy")]
        [SwaggerResponse(201, "Alleregy record created successfully", typeof(Guid))]
        [SwaggerResponse(400, "Invalid request")]
        public async Task<IActionResult> CreateAllergy([FromBody] CreateAllergyCommand command)
        {
            var allergyId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAllergyById), new { id = allergyId }, allergyId);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Updates an existing allergy")]
        [SwaggerResponse(204, "Allergy updated successfully")]
        [SwaggerResponse(400, "Invalid request")]
        public async Task<IActionResult> UpdateAllergy(Guid id, [FromBody] UpdateAllergyCommand command)
        {
            if (id != command.Id)
                return BadRequest("Allergy Id mismatch");

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets a Allergy by Id")]
        [SwaggerResponse(200, "Allergy retrieved successfully", typeof(GetAllergyByIdQueryResult))]
        [SwaggerResponse(404, "Allergy not found")]
        public async Task<IActionResult> GetAllergyById(Guid id)
        {
            var query = new GetAllergyIdQuery(id);
            var allergy = await _mediator.Send(query);

            if (allergy == null)
                return NotFound();

            return Ok(allergy);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets all allergies")]
        [SwaggerResponse(200, "Allergies retrieved successfully", typeof(List<GetAllAllergyQueryResult>))]
        public async Task<IActionResult> GetAllAllergies()
        {
            var query = new GetAllAllergyQuery();
            var allergies = await _mediator.Send(query);
            return Ok(allergies);
        }

        [HttpGet("patient/{patientId}")]
        [SwaggerOperation(Summary = "Gets all allergies for a patient")]
        [SwaggerResponse(200, "Allergies retrieved successfully", typeof(List<GetAllAllergyQueryResult>))]
        public async Task<IActionResult> GetAllAllergies(Guid patientId)
        {
            var query = new GetAllAllergyByPatientIdQuery(patientId);
            var allergies = await _mediator.Send(query);
            return Ok(allergies);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes a Allergy by Id")]
        [SwaggerResponse(204, "Allergy deleted successfully")]
        public async Task<IActionResult> DeleteAllergy(Guid id)
        {
            var command = new DeleteAllergyCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
