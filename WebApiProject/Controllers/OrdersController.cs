using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiProject.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/orders")]
    public class OrdersController : ControllerBase
    {
        // GET /api/v1/orders/{orderId}
        [HttpGet("{orderId}")]
        public IActionResult GetOrder(int orderId)
        {
            // Sample mock order data
            var order = new
            {
                OrderId = orderId,
                PatientId = 1,
                Items = new[]
                {
                    new { ItemId = 101, Name = "Blood Test", Quantity = 1, Price = 50.00 },
                    new { ItemId = 102, Name = "X-Ray", Quantity = 1, Price = 100.00 }
                },
                TotalAmount = 150.00,
                Status = "Completed",
                OrderDate = "2026-03-06"
            };

            if (order == null)
            {
                return NotFound("Order not found");
            }

            return Ok(order);
        }
    }
}
