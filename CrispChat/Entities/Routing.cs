using System.Text.Json.Serialization;

namespace CrispChat.Entities
{
    [BsonCollection("Routings")]
    public class Routing : EntityBase
    {
        [JsonPropertyName("assigned")]
        public Assigned Assigned { get; set; }
    }
}
