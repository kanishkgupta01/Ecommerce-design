using Ecom_RajasthanRoyals.Data;
using Ecom_RajasthanRoyals.Models.MongoDB;
using MongoDB.Driver;

namespace Ecom_RajasthanRoyals.Services
{
    public class WarehouseService
    {
        private readonly MongoDbService _mongo;

        public WarehouseService(MongoDbService mongo)
        {
            _mongo = mongo;
        }

        public async Task<List<Warehouse>> GetAllWarehousesAsync() =>
            await _mongo.Warehouses.Find(_ => true).ToListAsync();
    }
}
