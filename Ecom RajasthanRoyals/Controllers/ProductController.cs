using Ecom_RajasthanRoyals.DTOs;
using Ecom_RajasthanRoyals.Models.MongoDB;
using Ecom_RajasthanRoyals.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecom_RajasthanRoyals.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProductById(string id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Products>>> SearchProducts([FromQuery] string? name, [FromQuery] string? categoryId)
        {
            var products = await _productService.SearchAsync(name, categoryId);
            return Ok(products);
        }
    }
}
