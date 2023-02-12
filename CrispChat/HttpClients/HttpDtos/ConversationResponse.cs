using CrispChat.Entities;
using System.Text.Json.Serialization;

namespace CrispChat.HttpClients.HttpDtos
{
    public class ConversationResponse
    {
        [JsonPropertyName("error")]
        public bool Error { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        [JsonPropertyName("data")]
        public List<Conversation> Data { get; set; }
    }
}
