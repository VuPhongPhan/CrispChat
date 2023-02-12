using CrispChat.Configurations;
using CrispChat.Entities;
using CrispChat.Infrastructures;
using MongoDB.Driver;

namespace CrispChat.Repositories
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(IMongoClient client, DatabaseSettings settings) : base(client, settings)
        {
        }
    }
}
