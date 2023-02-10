namespace CrispChat.Entities
{
    public class Conversation : EntityBase<Guid>
    {
        public string SessionId { get; set; }
        public string Data { get; set; }


    }
}
