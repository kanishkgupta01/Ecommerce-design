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

        public async Task<InventoryDtocs> GetInventoryGroupedAsync(string warehouseId)
        {
            var inventoryList = await _mongo.Inventories.Find(i => i.WarehouseId == warehouseId).ToListAsync();
            var productIds = inventoryList.Select(x => x.ProductId).ToList();
            var products = await _mongo.Products.Find(p => productIds.Contains(p.Id)).ToListAsync();

            var grouped = products
                .GroupBy(p => p.CategoryId)
                .Select(g =>
                {
                    var category = new ProductCategory
                    {
                        CategoryId = g.Key,
                        Name = _categoryService.GetNameById(g.Key), // assume cached or static
                        Products = g.ToList()
                    };
                    return category;
                })
            .ToList();

            return new InventoryDtocs { Categories = grouped };
        }
    }
}
