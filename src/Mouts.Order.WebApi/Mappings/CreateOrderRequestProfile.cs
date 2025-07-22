using MoutsOrder.Application.Orders.CreateOrder;
using MoutsOrder.WebApi.Features.Orders.CreateOrder;
using AutoMapper;

namespace MoutsOrder.WebApi.Mappings;

public class CreateOrderRequestProfile : Profile
{
    public CreateOrderRequestProfile()
    {
        CreateMap<CreateOrderRequest, CreateOrderCommand>();
    }
}