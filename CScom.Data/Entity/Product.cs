using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace CScom.Data.Entity
{
    public class Product: BaseEntity
    {
        [BsonElement("productId")]
        public string ProductId { get; set; }

        [BsonElement("productName")]
        public string ProductName { get; set; }

        [BsonElement("categoryId")]
        public int CategoryId { get; set; }

        [BsonElement("inStock")]
        public bool InStock { get; set; }

        [BsonElement("status")]
        public int Status { get; set; }

        [BsonElement("stockCount")]
        public int StockCount { get; set; }

        [BsonElement("userBaskets")]
        public List<UserBasket> UserBaskets { get; set; }

        public class UserBasket
        {
            [BsonElement("userId")]
            public string UserId { get; set; }

            [BsonElement("basketId")]
            public string BasketId { get; set; }
        }
    }
}
