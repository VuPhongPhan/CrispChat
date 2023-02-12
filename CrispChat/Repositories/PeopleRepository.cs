using CrispChat.Configurations;
using CrispChat.Entities;
using CrispChat.Infrastructures;
using MongoDB.Driver;

namespace CrispChat.Repositories
{
    public class PeopleRepository : RepositoryBase<People>, IPeopleRepository
    {
        public PeopleRepository(IMongoClient client, DatabaseSettings settings) : base(client, settings)
        {
        }
    }
}
