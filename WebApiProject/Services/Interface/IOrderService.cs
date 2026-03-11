using WebApiProject.DTOs;

namespace WebApiProject.Services.Interface
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrderAsync(int orderId);
    }
}
