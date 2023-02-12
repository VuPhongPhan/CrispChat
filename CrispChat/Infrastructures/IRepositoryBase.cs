using CrispChat.Entities;
using MongoDB.Driver;

namespace CrispChat.Infrastructures
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        IMongoCollection<T> FindAll(ReadPreference? readPreference = null);

        Task CreateAsync(T entity);

        void Create(T entity);

        Task CreateManyAsync(IEnumerable<T> entities);

        void CreateMany(IEnumerable<T> entities);

        Task UpdateAsync(T entity);

        void Update(T entity);

        Task DeleteAsync(string id);

        Task<IEnumerable<T>> FindAsync(FilterDefinition<T> filter);


        Task BulkWriteAsync(IEnumerable<WriteModel<T>> writes);

        void BulkWrite(IEnumerable<WriteModel<T>> writes);

        Task<long> CountDocumentsAsync(FilterDefinition<T> filter);
    }
}
