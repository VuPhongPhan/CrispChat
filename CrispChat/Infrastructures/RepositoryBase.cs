using CrispChat.Configurations;
using CrispChat.Entities;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace CrispChat.Infrastructures
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        private IMongoDatabase Database { get; }
        public IMongoClient _client { get; }
        public RepositoryBase(IMongoClient client, DatabaseSettings settings)
        {
            Database = client.GetDatabase(settings.DatabaseName);
            _client = client;
        }
        protected virtual IMongoCollection<T> Collection => Database.GetCollection<T>(GetCollectionName());

        public IMongoCollection<T> FindAll(ReadPreference? readPreference = null) => Database.WithReadPreference(readPreference ?? ReadPreference.Primary)
            .GetCollection<T>(GetCollectionName());

        public Task CreateAsync(T entity) => Collection.InsertOneAsync(entity);

        public Task CreateManyAsync(IEnumerable<T> entities) => Collection.InsertManyAsync(entities);

        public void Create(T entity) => Collection.InsertOne(entity);

        public void CreateMany(IEnumerable<T> entities) => Collection.InsertMany(entities);

        public Task UpdateAsync(T entity)
        {
            Expression<Func<T, string>> func = f => f.Id;
            var value = (string)entity.GetType()
                .GetProperty(func.Body.ToString()
                .Split(".")[1])?.GetValue(entity, null);
            var filter = Builders<T>.Filter.Eq(func, value);

            return Collection.ReplaceOneAsync(filter, entity);
        }

        public void Update(T entity)
        {
            Expression<Func<T, string>> func = f => f.Id;
            var value = (string)entity.GetType()
                .GetProperty(func.Body.ToString()
                .Split(".")[1])?.GetValue(entity, null);
            var filter = Builders<T>.Filter.Eq(func, value);

            Collection.ReplaceOne(filter, entity);
        }

        public Task DeleteAsync(string id) => Collection.DeleteOneAsync(x => x.Id.Equals(id));


        private static string GetCollectionName()
            => (typeof(T).GetCustomAttributes(typeof(BsonCollectionAttribute), true)
                .FirstOrDefault() as BsonCollectionAttribute)?.CollectionName;


        public async Task BulkWriteAsync(IEnumerable<WriteModel<T>> writes)
           => await Collection.BulkWriteAsync(writes);

        public void BulkWrite(IEnumerable<WriteModel<T>> writes)
           => Collection.BulkWrite(writes);

        public async Task<long> CountDocumentsAsync(FilterDefinition<T> filter)
           => await Collection.CountDocumentsAsync(filter);

        public async Task<IEnumerable<T>> FindAsync(FilterDefinition<T> filter)
           => await Collection.Find(filter).ToListAsync();

        
    }
}
