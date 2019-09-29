using System;
using System.Collections.Generic;
using System.Text;

namespace CScom.Dto.Product
{
    public class ProductBasketDto
    {
        public string ProductId { get; set; }
        public string UserId { get; set; }
        public string BasketId { get; set; }
        public string ProductName { get; set; }
        public int ProductCount { get; set; }
        public int StockCount { get; set; }
        public bool InStock { get; set; }
        
    }
    
}
