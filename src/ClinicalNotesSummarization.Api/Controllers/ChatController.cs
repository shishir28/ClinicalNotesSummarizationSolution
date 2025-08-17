using ClinicalNotesSummarization.Application.Features.AI;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicalNotesSummarization.Api.Controllers
{
    public class PatientChatRequest
    {
        public string AgentKind { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ISummarizationService _summarizationService;

        public ChatController(ISummarizationService summarizationService) =>
            _summarizationService = summarizationService;

        [HttpPost("{patientId}")]
        [SwaggerOperation(Summary = "Gets a patient details")]
        [SwaggerResponse(200, "Data", typeof(string))]
        [SwaggerResponse(404, "Patient not found")]
        public async Task<IActionResult> SendPatientChatRequest(
                 [FromRoute] Guid patientId,
                 [FromBody] PatientChatRequest request)
        {
            bool IsInvalidRequest(Guid id, PatientChatRequest req) =>
                id == Guid.Empty ||
                string.IsNullOrEmpty(req.AgentKind) ||
                req.AgentKind != "SummarizePatient";

            if (IsInvalidRequest(patientId, request))
                return BadRequest("Invalid patient ID or agent kind.");

            var response = await _summarizationService.SummarizePatientAsync(patientId, CancellationToken.None);

            return Ok(response);
        }

        // [HttpPost("messages")]
        // [SwaggerOperation(Summary = "Send a message to the chat system")]
        // [SwaggerResponse(200, "Chat response", typeof(ChatMessageResponse))]
        // [SwaggerResponse(400, "Bad request")]
        // [SwaggerResponse(500, "Error processing chat message")]
        // public async Task<IActionResult> SendChatMessage([FromBody] Models.ChatMessageRequest request)
        // {
        //     try
        //     {
        //         var response = await _chatAgentService.SendChatMessageAsync(
        //             message: request.Message,
        //             conversationId: request.ConversationId,
        //             filter: request.Filter,
        //             nameSpace: request.Namespace
        //         );

        //         return Ok(response);
        //     }
        //     catch (HttpRequestException ex)
        //     {
        //         return StatusCode(500, $"Error communicating with chat service: {ex.Message}");
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
        //     }
        // }

    }
}
