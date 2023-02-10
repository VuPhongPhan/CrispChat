namespace CrispChat.Entities
{
    public interface IAuditTable
    {
        DateTimeOffset CreatedDate { get; set; }
        DateTimeOffset? ModifiedDate { get; set; }
    }
}
