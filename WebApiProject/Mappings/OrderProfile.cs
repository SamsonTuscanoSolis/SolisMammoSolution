using AutoMapper;
using WebApiProject.DTOs;
using WebApiProject.Models;

namespace WebApiProject.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
