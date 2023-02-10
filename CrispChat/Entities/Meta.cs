namespace CrispChat.Entities
{
    public class Meta : EntityBase<Guid>
    {
        public string SessionId { get; set; }
        public string Data { get; set; }
    }
}
