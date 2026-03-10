using WebApiProject.Models;

namespace WebApiProject.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(int orderId);
    }
}
