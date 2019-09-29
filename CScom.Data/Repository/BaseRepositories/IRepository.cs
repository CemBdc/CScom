using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CScom.Data.BaseRepositories.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        Task<TEntity> GetById(Guid id);
        Task<TEntity> GetById(string id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<bool> Update(TEntity obj, string id);
        Task<bool> Remove(string id);
    }
}
