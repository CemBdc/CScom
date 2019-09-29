using CScom.Data.UnitOfWork;
using CScom.Dto.Product;
using System.Threading.Tasks;

namespace CScom.Core.Product
{
    public class ProductService : IProductService 
    {
        IUnitOfWork _unitOfWork;
        
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CheckProductStock(string id)
        {
            var product = await _unitOfWork.ProductRepository.GetById(id);
            
            return product?.InStock ?? false;
            
        }

        public async Task<bool> AddToBasket(ProductBasketDto basketDto)
        {
            var product = await _unitOfWork.ProductRepository.GetById(basketDto.ProductId);

            if (product == null)
                return false;

            if (product.UserBaskets == null)
                product.UserBaskets = new System.Collections.Generic.List<Data.Entity.Product.UserBasket>();

            product.UserBaskets.Add(new Data.Entity.Product.UserBasket { BasketId = basketDto.BasketId, UserId = basketDto.UserId });

            var isUpdated = await _unitOfWork.ProductRepository.Update(product, basketDto.ProductId);
            await _unitOfWork.Commit();

            return isUpdated;

        }
        
    }
}
