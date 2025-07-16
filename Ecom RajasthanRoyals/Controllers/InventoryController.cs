using Ecom_RajasthanRoyals.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecom_RajasthanRoyals.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;
        public InventoryController(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(string productId)
        {
            var inventory = await _inventoryService.GetInventoryByProductAsync(productId);
            return Ok(inventory);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _inventoryService.GetAllInventoryAsync());
    }
}
