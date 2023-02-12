using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CrispChat.Entities
{
    public class EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string Id { get; protected init; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? ModifiedDate { get; set; } = DateTime.UtcNow;
    }
}
