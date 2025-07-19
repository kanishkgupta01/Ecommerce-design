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
            if (cart == null || cart.Items == null || !cart.Items.Any())
                throw new Exception("Cart is empty");

            var order = new Order
            {
                UserId = int.Parse(userId),
                WarehouseId = warehouseId,
                Status = "Placed",
                PaymentMode = paymentMode,
                CreatedAt = DateTime.Now,
                Items = cart.Items.Select(item => new OrderItem
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    CategoryId = item.CategoryId
                }).ToList(),
                  // still useful for reporting/summary
            };

            await _mongo.Orders.InsertOneAsync(order);

            // Optionally: clear the cart after placing order
            await _cartService.ClearCartAsync(userId);

            return order;
        }


        public async Task<List<Order>> GetOrdersByUser(int userId) =>
            await _mongo.Orders.Find(o => o.UserId == userId).ToListAsync();
    }
}
