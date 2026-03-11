using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Services.Interface;

namespace WebApiProject.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderService service, ILogger<OrdersController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET /api/v1/orders/{orderId}
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            _logger.LogInformation("API request received for OrderId: {OrderId}", orderId);

            var order = await _service.GetOrderAsync(orderId);

            if (order == null)
            {
                _logger.LogWarning("Order with OrderId {OrderId} not found", orderId);
                return NotFound("Order not found");
            }

            _logger.LogInformation("Returning order data for OrderId: {OrderId}", orderId);
            return Ok(order);
        }
    }
}
