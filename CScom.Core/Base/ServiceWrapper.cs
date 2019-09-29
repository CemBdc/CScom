using CScom.Core.Product;
using CScom.Data.UnitOfWork;

namespace CScom.Core.Base
{
    public class ServiceWrapper : IServiceWrapper
    {
        IUnitOfWork _unitOfWork;
        private IProductService _product;

        public ServiceWrapper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IProductService Product
        {
            get
            {
                if (_product == null)
                {
                    _product = new ProductService(_unitOfWork);
                }

                return _product;
            }
        }
    }
}
