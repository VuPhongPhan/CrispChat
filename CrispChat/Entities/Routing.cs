namespace CrispChat.Entities
{
    public class Routing : EntityBase<Guid>
    {
        public string SessionId { get; set; }
        public string UserId { get; set; }
    }
}
