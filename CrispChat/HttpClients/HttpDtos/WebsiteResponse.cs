using CrispChat.Entities;
using System.Text.Json.Serialization;

namespace CrispChat.HttpClients.HttpDtos
{
    public class WebsiteResponse
    {
        [JsonPropertyName("error")]
        public bool Error { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        [JsonPropertyName("data")]
        public Website Data { get; set; }
    }
}
