using Ecom_RajasthanRoyals.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecom_RajasthanRoyals.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly WarehouseService _warehouseService;
        private readonly InventoryService _inventoryService;

        public WarehouseController(WarehouseService warehouseService, InventoryService inventoryService)
        {
            _warehouseService = warehouseService;
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _warehouseService.GetAllWarehousesAsync());


      
    }
}
