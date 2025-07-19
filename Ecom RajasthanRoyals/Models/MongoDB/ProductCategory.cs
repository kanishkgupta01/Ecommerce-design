using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Ecom_RajasthanRoyals.Models.MongoDB
{
    public class ProductCategory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }  // Mongo-generated ObjectId

        [BsonElement("name")]
        public string Name { get; set; }
    }

}
