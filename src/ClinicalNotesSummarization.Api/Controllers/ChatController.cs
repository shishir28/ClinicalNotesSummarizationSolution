using ClinicalNotesSummarization.Application.Features.AI;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicalNotesSummarization.Api.Controllers
{
    public class PatientChatRequest
    {
        public string AgentKind { get; set; } = string.Empty;
    }

    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ISummarizationService _summarizationService;
        private readonly IPatientChatService _patientChatService;

        public ChatController(ISummarizationService summarizationService,
            IPatientChatService patientChatService)
        {
            _summarizationService = summarizationService;
            _patientChatService = patientChatService;
        }

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

        public class ChatMessageRequest
        {
            public string Message { get; set; } = string.Empty;
            public int TopKDocs { get; set; } = 8;
            public int TopKPatients { get; set; } = 5;
        }

        [HttpPost("{patientId}/message")]
        [SwaggerOperation(Summary = "Send a message scoped to a patient using RAG retrieval and LLM reply")]
        [SwaggerResponse(200, "Chat response", typeof(object))]
        public async Task<IActionResult> SendPatientMessage([FromRoute] Guid patientId, [FromBody] ChatMessageRequest req)
        {
            if (patientId == Guid.Empty || string.IsNullOrWhiteSpace(req?.Message))
                return BadRequest("Invalid patient id or empty message.");

            var dto = new PatientChatRequestDto
            {
                Message = req.Message,
                TopKDocs = req.TopKDocs,
                TopKPatients = req.TopKPatients
            };

            var res = await _patientChatService.SendPatientMessageAsync(patientId, dto, CancellationToken.None);
            return Ok(res);
        }

        [HttpPost("search/patients")]
        [SwaggerOperation(Summary = "Search patients by free-text query using vector retrieval")]
        public async Task<IActionResult> SearchPatients([FromBody] ChatMessageRequest req)
        {
            if (string.IsNullOrWhiteSpace(req?.Message)) return BadRequest("Query is required.");
            var dto = new PatientChatRequestDto
            {
                Message = req.Message,
                TopKDocs = req.TopKDocs,
                TopKPatients = req.TopKPatients
            };

            var res = await _patientChatService.SearchPatientsAsync(dto, CancellationToken.None);
            return Ok(res);
        }
    }
}
