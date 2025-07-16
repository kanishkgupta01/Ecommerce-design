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

        public async Task AddToCartAsync(string userId, int categoryId, int quantity)
        {
            var cart = await _mongo.Carts.Find(c => c.Id == userId).FirstOrDefaultAsync()
                       ?? new Cart { Id = userId, CategoryIdVsCount = new() };

            string key = categoryId.ToString();

            if (cart.CategoryIdVsCount.ContainsKey(key))
                cart.CategoryIdVsCount[key] += quantity;
            else
                cart.CategoryIdVsCount[key] = quantity;

            await _mongo.Carts.ReplaceOneAsync(c => c.Id == userId, cart, new ReplaceOptions { IsUpsert = true });
        }

        public async Task RemoveFromCartAsync(string userId, int categoryId)
        {
            var cart = await GetCartAsync(userId);
            if (cart == null || cart.CategoryIdVsCount == null) return;

            string key = categoryId.ToString();
            if (cart.CategoryIdVsCount.ContainsKey(key))
            {
                cart.CategoryIdVsCount.Remove(key);
                await _mongo.Carts.ReplaceOneAsync(c => c.Id == userId, cart);
            }
        }

        public async Task ClearCartAsync(string userId) =>
            await _mongo.Carts.DeleteOneAsync(c => c.Id == userId);
    }
}
