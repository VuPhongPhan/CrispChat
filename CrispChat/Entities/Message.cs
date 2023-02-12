using System.Text.Json.Serialization;

namespace CrispChat.Entities
{
    [BsonCollection("Messages")]
    public class Message : EntityBase
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
        public List<Preview> Preview { get; set; }

        [JsonPropertyName("mentions")]
        public List<string> Mentions { get; set; }

        [JsonPropertyName("stamped")]
        public bool Stamped { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

    }
    public class Preview
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("timestamp")]
        public string title { get; set; }

        [JsonPropertyName("preview")]
        public PreviewParam PreviewParam { get; set; }

    }

    public class PreviewParam
    {
        [JsonPropertyName("excerpt")]
        public string Excerpt { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("embed")]
        public string Embed { get; set; }
    }
}
