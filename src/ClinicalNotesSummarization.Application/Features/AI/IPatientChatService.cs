using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClinicalNotesSummarization.Application.Features.AI;

public interface IPatientChatService
{
    Task<PatientChatResponseDto> SendPatientMessageAsync(Guid patientId, PatientChatRequestDto request, CancellationToken cancellationToken = default);
    Task<object> SearchPatientsAsync(PatientChatRequestDto request, CancellationToken cancellationToken = default);
}

public class PatientChatRequestDto
{
    public string Message { get; set; } = string.Empty;
    public int TopKDocs { get; set; } = 8;
    public int TopKPatients { get; set; } = 5;
}

public class PatientChatResponseDto
{
    public Guid ConversationId { get; set; }
    public string Reply { get; set; } = string.Empty;
    public object? Sources { get; set; }
}
