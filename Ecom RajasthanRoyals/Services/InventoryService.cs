using Ecom_RajasthanRoyals.Data;
using Ecom_RajasthanRoyals.DTOs;
using Ecom_RajasthanRoyals.Models.MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ecom_RajasthanRoyals.Services
{
    public class InventoryService
    {
        private readonly MongoDbService _mongo;
        private readonly ICategoryService _categoryService;

        public InventoryService(MongoDbService mongo, ICategoryService categoryService)
        {
            _mongo = mongo;
            _categoryService = categoryService;
        }

        public async Task<List<Inventory>> GetInventoryByProductAsync(string productId)
        {

            if (!ObjectId.TryParse(productId, out var objectId))
            {
                Console.WriteLine($"[ERROR] Invalid ObjectId: {productId}");
                return new List<Inventory>();
            }

            var filter = Builders<Inventory>.Filter.Eq(i => i.ProductId, objectId.ToString());
            var results = await _mongo.Inventories.Find(filter).ToListAsync();

            Console.WriteLine($"[DEBUG] Found {results.Count} entries for ProductId {objectId}");

            return results;

        }
        

        public async Task<List<Inventory>> GetAllInventoryAsync() =>
            await _mongo.Inventories.Find(_ => true).ToListAsync();


    

    }
}
