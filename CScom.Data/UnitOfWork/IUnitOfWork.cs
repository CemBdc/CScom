using CScom.Data.BaseRepositories.Repository;
using CScom.Data.Repository.EntityRepositories.ProductRepository;
using System.Threading.Tasks;

namespace CScom.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IRepository<T> GetRepository<T>() where T : class;
        Task<bool> Commit();
    }
}
