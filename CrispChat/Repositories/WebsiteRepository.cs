using CrispChat.Configurations;
using CrispChat.Entities;
using CrispChat.Infrastructures;
using MongoDB.Driver;

namespace CrispChat.Repositories
{
    public class WebsiteRepository : RepositoryBase<Website>, IWebsiteRepository
    {
        public WebsiteRepository(IMongoClient client, DatabaseSettings settings) : base(client, settings)
        {
        }
    }
}
