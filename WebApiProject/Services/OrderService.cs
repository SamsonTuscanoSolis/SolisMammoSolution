using AutoMapper;
using WebApiProject.DTOs;
using WebApiProject.Repositories.Interface;
using WebApiProject.Services.Interface;

namespace WebApiProject.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderRepository repository, IMapper mapper, ILogger<OrderService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OrderDto> GetOrderAsync(int orderId)
        {
            _logger.LogInformation("Getting order with OrderId {OrderId}", orderId);

            var order = await _repository.GetOrderByIdAsync(orderId);

            if (order == null)
            {
                _logger.LogWarning("Order with OrderId {OrderId} not found", orderId);
                return null;
            }

            var orderDto = _mapper.Map<OrderDto>(order);

            _logger.LogInformation("Returning order data for OrderId {OrderId}", orderId);

            return orderDto;
        }
    }
}
