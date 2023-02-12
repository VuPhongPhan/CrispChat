using CrispChat.Entities;
using System.Text.Json.Serialization;

namespace CrispChat.HttpClients.HttpDtos
{
    public class MessageResponse
    {
        [JsonPropertyName("error")]
        public bool Error { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        [JsonPropertyName("data")]
        public List<Message> Data { get; set; }
    }
}
