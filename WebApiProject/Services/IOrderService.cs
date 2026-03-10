using WebApiProject.DTOs;

namespace WebApiProject.Services
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrderAsync(int orderId);
    }
}
