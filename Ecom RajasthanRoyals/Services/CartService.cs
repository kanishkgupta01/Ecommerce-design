using Ecom_RajasthanRoyals.Data;
using Ecom_RajasthanRoyals.Models.MongoDB;
using MongoDB.Driver;

namespace Ecom_RajasthanRoyals.Services
{
    public class CartService
    {
        private readonly MongoDbService _mongo;

        public CartService(MongoDbService mongo)
        {
            _mongo = mongo;
        }

        public async Task<Cart> GetCartAsync(string userId) =>
            await _mongo.Carts.Find(c => c.Id == userId.ToString()).FirstOrDefaultAsync();

        public async Task AddToCartAsync(string userId, string productId, int quantity)
        {
            var cart = await _mongo.Carts.Find(c => c.Id == userId).FirstOrDefaultAsync()
                       ?? new Cart { Id = userId };

            var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                // Fetch product details
                var product = await _mongo.Products.Find(p => p.Id == productId).FirstOrDefaultAsync();
                if (product == null) throw new Exception("Product not found.");

                cart.Items.Add(new CartItem
                {
                    ProductId = productId,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = quantity,
                    CategoryId = product.CategoryId
                });
            }

            await _mongo.Carts.ReplaceOneAsync(c => c.Id == userId, cart, new ReplaceOptions { IsUpsert = true });
        }



        public async Task RemoveFromCartAsync(string userId, string productId)
        {
            var cart = await GetCartAsync(userId);
            if (cart == null || cart.Items == null) return;

            cart.Items.RemoveAll(item => item.ProductId == productId);

            await _mongo.Carts.ReplaceOneAsync(c => c.Id == userId, cart);
        }

        public async Task ClearCartAsync(string userId) =>
            await _mongo.Carts.DeleteOneAsync(c => c.Id == userId);
    }
}
