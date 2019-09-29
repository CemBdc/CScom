using CScom.Dto.Product;
using System.Threading.Tasks;

namespace CScom.Core.Product
{
    public interface IProductService
    {
        Task<bool> CheckProductStock(string id);
        Task<bool> AddToBasket(ProductBasketDto basketDto);
    }
}
