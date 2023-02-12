using CrispChat.Entities;
using System.Text.Json.Serialization;

namespace CrispChat.HttpClients.HttpDtos
{
    public class RoutingResponse
    {
        [JsonPropertyName("error")]
        public bool Error { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        [JsonPropertyName("data")]
        public Routing Data { get; set; }
    }
}
