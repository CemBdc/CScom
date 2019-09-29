using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CScom.Data.Entity
{
    public class BaseEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonDateTimeOptions]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string CreatedUser { get; set; }

        [BsonDateTimeOptions]
        public DateTime UpdatedDate { get; set; }

        public string UpdatedUser { get; set; }
    }
}
