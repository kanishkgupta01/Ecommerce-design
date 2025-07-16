using Ecom_RajasthanRoyals.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecom_RajasthanRoyals.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController: ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

      
        [HttpPost("place")]
        public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderRequest request)
        {
            var order = await _orderService.PlaceOrderAsync(request.UserId, request.WarehouseId, request.PaymentMode);
            return Ok(order);
        }


        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserOrders(int userId)
        {
            var orders = await _orderService.GetOrdersByUser(userId);
            return Ok(orders);
        }


        public class PlaceOrderRequest
        {
            public string UserId { get; set; }
            public string WarehouseId { get; set; }
            public string PaymentMode { get; set; }
        }
    }
}
