using CrispChat.Configurations;
using CrispChat.Entities;
using CrispChat.Infrastructures;
using MongoDB.Driver;

namespace CrispChat.Repositories
{
    public class SegmentRepository : RepositoryBase<Segment>, ISegmentRepository
    {
        public SegmentRepository(IMongoClient client, DatabaseSettings settings) : base(client, settings)
        {
        }
    }
}
