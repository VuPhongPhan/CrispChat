using System.Text.Json.Serialization;

namespace CrispChat.Entities
{
    [BsonCollection("Websites")]
    public class Website : EntityBase
    {
        [JsonPropertyName("website_id")]
        public string WebsiteId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("domain")]
        public string Domain { get; set; }


        [JsonPropertyName("logo")]
        public string Logo { get; set; }
    }
}
