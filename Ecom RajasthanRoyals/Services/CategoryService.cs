using Ecom_RajasthanRoyals.Data;
using Ecom_RajasthanRoyals.Models.MongoDB;
using MongoDB.Driver;

namespace Ecom_RajasthanRoyals.Services
{


    public class CategoryService 
    {
        private readonly MongoDbService _mongo;
      
        public CategoryService(MongoDbService mongo)
        {
            _mongo = mongo;
           
        }

        public async Task<List<ProductCategory>> GetAllCategoriesAsync() =>
          await _mongo.ProductCategories.Find(_ => true).ToListAsync();
    }
}
