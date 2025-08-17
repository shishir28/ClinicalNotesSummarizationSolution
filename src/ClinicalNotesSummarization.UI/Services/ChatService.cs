using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using ClinicalNotesSummarization.UI.Models;


namespace ClinicalNotesSummarization.UI.Services;

public interface IChatService
{
    Task<JsonElement> SendMessageAsync(PatientDto patient, string agentKind);

    Task<ChatMessageResponse> SendChatMessageAsync(string message, string? conversationId = null, Dictionary<string, object>? filter = null, string? nameSpace = null);
}

public class ChatService : IChatService
{
    private readonly HttpClient _httpClient;

    public ChatService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<JsonElement> SendMessageAsync(PatientDto patient, string agentKind)
    {
        var request = new
        {
            AgentKind = agentKind,
        };

        var response = await _httpClient.PostAsJsonAsync($"api/chat/{patient.Id}", request);

        if (!response.IsSuccessStatusCode)
            return EmptyJsonElement();

        try
        {
            await using var stream = await response.Content.ReadAsStreamAsync();
            using var doc = await JsonDocument.ParseAsync(stream);
            var root = doc.RootElement.Clone();

            if (root.ValueKind != JsonValueKind.Undefined && root.TryGetProperty("summaryText", out var _))
            {
                return root;
            }
        }
        catch (JsonException)
        {
            // fall through and return empty
        }

        return EmptyJsonElement();
    }
    private static JsonElement EmptyJsonElement() => StringAsJsonElement("{}");
    private static JsonElement StringAsJsonElement(string value)
    {
        using var parsedSummaryDocument = JsonDocument.Parse(value);
        return parsedSummaryDocument.RootElement.Clone();
    }

    public async Task<ChatMessageResponse> SendChatMessageAsync(string message, string? conversationId = null, Dictionary<string, object>? filter = null, string? nameSpace = null)
    {
        var request = new ChatMessageRequest
        {
            Message = message,
            ConversationId = conversationId,
            Filter = filter,
            Namespace = nameSpace
        };

        var response = await _httpClient.PostAsJsonAsync("api/chat/messages", request);

        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException($"Chat request failed: {response.StatusCode}");

        var chatResponse = await response.Content.ReadFromJsonAsync<ChatMessageResponse>();

        if (chatResponse == null)
            throw new InvalidOperationException("Failed to deserialize chat response.");

        return chatResponse;
    }
}