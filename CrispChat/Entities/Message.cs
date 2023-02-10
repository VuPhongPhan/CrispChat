namespace CrispChat.Entities
{
    public class Message : EntityBase<Guid>
    {
        public string SessionId { get; set; }
        public string Data { get; set; }

    }
}
