using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Ecom_RajasthanRoyals.Models.MongoDB
{
    public class ProductCategory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public List<Products> Products { get; set; } = new();
    }
}
