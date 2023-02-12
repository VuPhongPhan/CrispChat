using CrispChat.Entities;
using CrispChat.Infrastructures;

namespace CrispChat.Repositories
{
    public interface IConversationRepository : IRepositoryBase<Conversation>
    {
        Task<IList<Conversation>> GetSyncPaging();
    }
}
