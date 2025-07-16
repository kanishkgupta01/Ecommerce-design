using Ecom_RajasthanRoyals.Models.MongoDB;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Ecom_RajasthanRoyals.Data
{
    public class MongoDbService
    {

        private readonly IMongoDatabase _database;

        public MongoDbService(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Products> Products => _database.GetCollection<Products>("Products");
        public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Orders");

        public IMongoCollection<Cart> Carts => _database.GetCollection<Cart>("Carts");

        public IMongoCollection<Inventory> Inventories => _database.GetCollection<Inventory>("Inventory");
        public IMongoCollection<Warehouse> Warehouses => _database.GetCollection<Warehouse>("Warehouses");
    }
}
