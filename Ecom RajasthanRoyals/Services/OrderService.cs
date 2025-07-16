using Ecom_RajasthanRoyals.Data;
using Ecom_RajasthanRoyals.Models.MongoDB;
using MongoDB.Driver;

namespace Ecom_RajasthanRoyals.Services
{
    public class OrderService
    {
        private readonly MongoDbService _mongo;
        private readonly CartService _cartService;

        public OrderService(MongoDbService mongo, CartService cartService)
        {
            _mongo = mongo;
            _cartService = cartService;
        }

        public async Task<Order> PlaceOrderAsync(string userId, string warehouseId, string paymentMode)
        {
            var cart = await _cartService.GetCartAsync(userId);
            if (cart == null || !cart.CategoryIdVsCount.Any()) throw new Exception("Cart is empty");

            var order = new Order
            {
                UserId = int.Parse(userId),
                WarehouseId = warehouseId,
                OrderStatus = "Placed",
                PaymentMode = paymentMode,
                CategoryIdVsCount = cart.CategoryIdVsCount,
                CreatedAt = DateTime.Now
            };

            await _mongo.Orders.InsertOneAsync(order);
            return order;
        }

        public async Task<List<Order>> GetOrdersByUser(int userId) =>
            await _mongo.Orders.Find(o => o.UserId == userId).ToListAsync();
    }
}
