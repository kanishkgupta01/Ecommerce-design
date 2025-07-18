﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ecom_RajasthanRoyals.Models.MongoDB
{
    [BsonIgnoreExtraElements]
    public class Order
    {

            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }

            public int UserId { get; set; }

            [BsonRepresentation(BsonType.ObjectId)]
            public string WarehouseId { get; set; }

            public int AddressId { get; set; }

            public Dictionary<string, int> CategoryIdVsCount { get; set; } = new();

            public List<OrderItem> Items { get; set; } = new();  

            public string PaymentMode { get; set; }

            public string Status { get; set; } 

            [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
            public DateTime CreatedAt { get; set; }
        }

    
    public class OrderItem
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string CategoryId { get; set; }
    }
}
