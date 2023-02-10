namespace CrispChat.Entities
{
    public class Config : EntityBase<Guid>
    {
        public int WebsiteId { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Logo { get; set; }
    }
}
