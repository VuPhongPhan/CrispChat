namespace CrispChat.Entities
{
    public class Visitor : EntityBase<Guid>
    {
        public string SessionId { get; set; }
        public string Data { get; set; }
    }
}
