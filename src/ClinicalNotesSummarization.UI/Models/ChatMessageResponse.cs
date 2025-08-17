using System.Text.Json.Serialization;

namespace ClinicalNotesSummarization.UI.Models;

public class ChatMessageResponse
{
    [JsonPropertyName("conversation_id")]
    public string ConversationId { get; set; } = string.Empty;

    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    // [JsonPropertyName("source_documents")]
    // public List<SourceDocument> SourceDocuments { get; set; } = [];

    [JsonPropertyName("generated_question")]
    public string GeneratedQuestion { get; set; } = string.Empty;
}

// public class SourceDocument
// {
//     [JsonPropertyName("content")]
//     public string Content { get; set; } = string.Empty;

//     [JsonPropertyName("metadata")]
//     public Dictionary<string, object> Metadata { get; set; } = new();
// }