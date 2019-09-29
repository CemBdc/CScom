using System.ComponentModel.DataAnnotations;

namespace CScom.Api.Model.Product
{
    public class BasketProduct : IModel
    {
        [Required(ErrorMessage = "ProductId is required")]
        public string ProductId { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "BasketId is required")]
        public string BasketId { get; set; }

        [Required(ErrorMessage = "ProductName is required")]
        public string ProductName { get; set; }

        [Range(1, 10, ErrorMessage = "Allowed at least 1 product, maximum 10 products to basket")]
        public int ProductCount { get; set; }
    }
}
