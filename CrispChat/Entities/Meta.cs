using System.Text.Json.Serialization;

namespace CrispChat.Entities
{
    [BsonCollection("Metas")]
    public class Metas : EntityBase
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

        //[JsonPropertyName("data")]
        //public DataData Data { get; set; }

        [JsonPropertyName("device")]
        public Device Device { get; set; }

        [JsonPropertyName("segments")]
        public List<string> Segments { get; set; }
    }
}
