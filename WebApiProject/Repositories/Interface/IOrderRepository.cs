using WebApiProject.Models;

namespace WebApiProject.Repositories.Interface
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(int orderId);
    }
}
