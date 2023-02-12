using CrispChat.Configurations;
using CrispChat.Entities;
using CrispChat.Infrastructures;
using MongoDB.Driver;

namespace CrispChat.Repositories
{
    public class MetaRepository : RepositoryBase<Metas>, IMetaRepository
    {
        public MetaRepository(IMongoClient client, DatabaseSettings settings) : base(client, settings)
        {
        }
    }
}
