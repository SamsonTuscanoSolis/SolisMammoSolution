using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApiProject.Data;
using WebApiProject.Models;

namespace WebApiProject.Repositories
{
        public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(AppDbContext context, ILogger<OrderRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            _logger.LogInformation("Fetching order with OrderId {OrderId}", orderId);

            var order = await _context.Orders
                                      .Include(o => o.Items)  // Assuming the order has related order items
                                      .FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order == null)
            {
                _logger.LogWarning("Order with OrderId {OrderId} not found", orderId);
            }

            return order;
        }
    }
}
