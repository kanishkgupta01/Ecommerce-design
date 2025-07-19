using Ecom_RajasthanRoyals.Data;
using Ecom_RajasthanRoyals.DTOs;
using Ecom_RajasthanRoyals.Models.MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ecom_RajasthanRoyals.Services
{
    public class ProductService
    {
        private readonly MongoDbService _mongoService;

        public ProductService(MongoDbService mongoService)
        {
            _mongoService = mongoService;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await _mongoService.Products.Find(_ => true).ToListAsync();
            var categories = await _mongoService.ProductCategories.Find(_ => true).ToListAsync();

            var categoryMap = categories.ToDictionary(c => c.Id, c => c.Name);

            var result = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                CategoryId = p.CategoryId,
                CategoryName = categoryMap.ContainsKey(p.CategoryId) ? categoryMap[p.CategoryId] : "Unknown",
                Price = p.Price,
                Description = p.Description
            }).ToList();

            return result;
        }

        public async Task<Products> GetProductByIdAsync(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
                throw new FormatException($"'{id}' is not a valid 24-digit hex string.");

            return await _mongoService.Products.Find(p => p.Id == objectId.ToString()).FirstOrDefaultAsync();
        }

   
        public async Task<List<Products>> SearchAsync(string name, string categoryId)
        {
            var filterBuilder = Builders<Products>.Filter;
            var filter = FilterDefinition<Products>.Empty;
            
            /*
            var s = Builders<Products>.Sort.Descending(p => p.Name);
            var result = await _mongoService.Products.Find(filter)
                             .Sort(s)
                             .ToListAsync();
            */
           
           
            if (!string.IsNullOrEmpty(name))
                filter &= filterBuilder.Regex("Name", new BsonRegularExpression(name, "i"));

            if (!string.IsNullOrEmpty(categoryId))
                filter &= filterBuilder.Eq(p => p.CategoryId, categoryId);

         

            return await _mongoService.Products.Find(filter).ToListAsync();
        }

      

    }
}
