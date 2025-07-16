using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ecom_RajasthanRoyals.Models.MongoDB
{
    public class Inventory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string WarehouseId { get; set; }
        public int Quantity { get; set; }
    }
}
