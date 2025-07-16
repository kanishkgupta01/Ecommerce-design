using Ecom_RajasthanRoyals.DTOs;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ecom_RajasthanRoyals.Models.MongoDB
{
    public class Warehouse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public InventoryDtocs Inventory { get; set; }
    }
}
