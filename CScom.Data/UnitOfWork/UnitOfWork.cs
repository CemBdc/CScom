using CScom.Common.Enum;
using CScom.Data.BaseRepositories.Repository;
using CScom.Data.Context;
using CScom.Data.Repository.BaseRepositories;
using CScom.Data.Repository.EntityRepositories.ProductRepository;
using System;
using System.Threading.Tasks;

namespace CScom.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;

        private IProductRepository _productRepository;

        public UnitOfWork(IMongoContext context)
        {
            _context = context;
        }
        
        public IProductRepository ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                    this._productRepository = new ProductRepository(_context);
                return _productRepository;
            }
        }

        public async Task<bool> Commit()
        {
            var changeAmount = await _context.SaveChanges();

            return changeAmount > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }
        
        public IBaseRepository GetRepository(RepositoryType type)
        {
            switch (type)
            {
                case RepositoryType.ProductRepository:
                    return new ProductRepository(_context);
                default:
                    throw new NotSupportedException();
            }

            
        }
        

    }
}
