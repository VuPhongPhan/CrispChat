using CrispChat.Configurations;
using CrispChat.Entities;
using CrispChat.Infrastructures;
using MongoDB.Driver;

namespace CrispChat.Repositories
{
    public class VisitorRepository : RepositoryBase<Visitor>, IVisitorRepository
    {
        public VisitorRepository(IMongoClient client, DatabaseSettings settings) : base(client, settings)
        {
        }
    }
}
