using AutoMapper;
using SQL.Application.Features.Orders.Commands.CheckoutOrder;
using SQL.Application.Features.Orders.Commands.UpdateOrder;
using SQL.Application.Features.Orders.Queries.GetOrdersList;
using SQL.Domain.Entities;

namespace SQL.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrdersVm>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}
