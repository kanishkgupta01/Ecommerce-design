using Ecom_RajasthanRoyals.Models.MongoDB;
using Ecom_RajasthanRoyals.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecom_RajasthanRoyals.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<Cart>> GetCart(string userId) =>
            Ok(await _cartService.GetCartAsync(userId));

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartRequest request)
        {
            await _cartService.AddToCartAsync(request.UserId, request.CategoryId, request.Quantity);
            return Ok();
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveFromCart([FromQuery] string userId, [FromQuery] int categoryId)
        {
            await _cartService.RemoveFromCartAsync(userId, categoryId);
            return Ok();
        }

        [HttpDelete("clear/{userId}")]
        public async Task<IActionResult> ClearCart(string userId)
        {
            await _cartService.ClearCartAsync(userId);
            return Ok();
        }
        public class AddToCartRequest
        {
            public string UserId { get; set; }
            public int CategoryId { get; set; }
            public int Quantity { get; set; }
        }
    }
}
