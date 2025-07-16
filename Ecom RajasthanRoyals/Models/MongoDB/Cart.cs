using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ecom_RajasthanRoyals.Models.MongoDB
{
    public class Cart
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; } // use UserId as Id
        public List<CartItem> Items { get; set; } = new();

        public Dictionary<string, int> CategoryIdVsCount { get; set; } = new();
    }

    public class CartItem
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
