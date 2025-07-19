using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ecom_RajasthanRoyals.Models.MongoDB
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("categoryId")]
        public string CategoryId { get; set; } 

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }
    }
}
