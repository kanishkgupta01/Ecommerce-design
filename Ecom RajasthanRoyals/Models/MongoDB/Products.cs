using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ecom_RajasthanRoyals.Models.MongoDB
{
    public class Products
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
