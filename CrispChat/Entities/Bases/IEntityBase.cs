namespace CrispChat.Entities
{
    public interface IEntityBase<TKey> : IAuditTable
    {
        TKey Id { get; set; }
    }
}
