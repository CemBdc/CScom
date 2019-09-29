using CScom.Data.BaseRepositories.Repository;
using CScom.Data.Context;
using CScom.Data.Entity;
using CScom.Data.Repository.BaseRepositories;

namespace CScom.Data.Repository.EntityRepositories.ProductRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository, IBaseRepository
    {
        public ProductRepository(IMongoContext context) : base(context)
        {
        }
        
    }
}
