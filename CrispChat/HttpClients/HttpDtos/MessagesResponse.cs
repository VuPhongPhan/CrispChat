using System.Text.Json.Serialization;

namespace CrispChat.HttpClients.HttpDtos
{
    public class MessagesResponse
    {
        [JsonPropertyName("error")]
        public bool Error { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        [JsonPropertyName("data")]
        public List<MessageData> Data { get; set; }
    }

    public partial class MessageData
    {
        [JsonPropertyName("session_id")]
        public string SessionId { get; set; }

        [JsonPropertyName("website_id")]
        public string WebsiteId { get; set; }

        [JsonPropertyName("fingerprint")]
        public long Fingerprint { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("from")]
        public string From { get; set; }

        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        //[JsonPropertyName("content")]
        //public string Content { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("delivered")]
        public string Delivered { get; set; }

        [JsonPropertyName("read")]
        public string Read { get; set; }

        [JsonPropertyName("preview")]
        public List<object> Preview { get; set; }

        [JsonPropertyName("mentions")]
        public List<object> Mentions { get; set; }

        [JsonPropertyName("stamped")]
        public bool Stamped { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }
    }
}
