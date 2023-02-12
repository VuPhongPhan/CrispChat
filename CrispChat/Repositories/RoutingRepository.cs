using CrispChat.Configurations;
using CrispChat.Entities;
using CrispChat.Infrastructures;
using MongoDB.Driver;

namespace CrispChat.Repositories
{
    public class RoutingRepository : RepositoryBase<Routing>, IRoutingRepository
    {
        public RoutingRepository(IMongoClient client, DatabaseSettings settings) : base(client, settings)
        {
        }
    }
}
