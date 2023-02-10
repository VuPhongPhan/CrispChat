namespace CrispChat.Entities
{
    public class People : EntityBase<Guid>
    {
        public string PeopleId { get; set; }
        public string Data { get; set; }
    }
}
