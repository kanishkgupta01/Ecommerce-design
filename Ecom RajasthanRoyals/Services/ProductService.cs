using Ecom_RajasthanRoyals.Data;
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

        public async Task<List<Products>> GetAllAsync() =>
            await _mongoService.Products.Find(_ => true).ToListAsync();

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

            if (!string.IsNullOrEmpty(name))
                filter &= filterBuilder.Regex("Name", new BsonRegularExpression(name, "i"));

            if (int.TryParse(categoryId, out int catId))
                filter &= filterBuilder.Eq(p => p.CategoryId, catId);

            return await _mongoService.Products.Find(filter).ToListAsync();
        }
    }
}
