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
        public DataRouting Data { get; set; }
    }

    public partial class DataRouting
    {
        [JsonPropertyName("assigned")]
        public Assigned Assigned { get; set; }
    }
}
