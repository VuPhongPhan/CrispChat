using CrispChat.Configurations;
using CrispChat.Entities;
using CrispChat.Infrastructures;
using MongoDB.Driver;

namespace CrispChat.Repositories
{
    public class ConversationRepository : RepositoryBase<Conversation>, IConversationRepository
    {
        public ConversationRepository(IMongoClient client, DatabaseSettings settings) : base(client, settings)
        {
        }

        public async Task<IList<Conversation>> GetSyncPaging()
            => await Collection.Find(x => !x.IsSync).Skip(0).Limit(20).ToListAsync();
    }
}
