using CScom.Data.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CScom.Data.BaseRepositories.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoContext _context;
        protected readonly IMongoCollection<TEntity> DbSet;

        public Repository(IMongoContext context)
        {
            _context = context;
            DbSet = _context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public void Add(TEntity obj)
        {
            _context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        public async Task<TEntity> GetById(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public async Task<TEntity> GetById(string id)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("productId", id));
            return data.SingleOrDefault();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public async Task<bool> Update(TEntity obj, string id)
        {
            var builder = Builders<TEntity>.Filter;
            var filter = builder.Eq("productId", id);

            var updateResult = await DbSet.ReplaceOneAsync(filter: filter, replacement: obj);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
            
        }

        public async Task<bool> Remove(string id)
        {
            var builder = Builders<TEntity>.Filter;
            var filter = builder.Eq("_id", id);

            var deleteResult = await DbSet.DeleteOneAsync(filter: filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
            
        }
        
        public void Dispose()
        {
            _context?.Dispose();
        }
        
    }
}
