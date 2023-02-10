using System.Text.Json.Serialization;

namespace CrispChat.HttpClients.HttpDtos
{
    public class MetasReponse
    {
        [JsonPropertyName("error")]
        public bool Error { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        [JsonPropertyName("data")]
        public MetasData Data { get; set; }
    }

    public partial class MetasData
    {
        [JsonPropertyName("nickname")]
        public string Nickname { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        [JsonPropertyName("data")]
        public DataData Data { get; set; }

        [JsonPropertyName("device")]
        public Device Device { get; set; }

        [JsonPropertyName("segments")]
        public List<string> Segments { get; set; }
    }

    public partial class DataData
    {
    }
}

