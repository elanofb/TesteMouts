using MoutsOrder.Application.OrderItems.CreateOrderItem;
using MoutsOrder.WebApi.Features.OrderItems.CreateOrderItems;
      
using AutoMapper;

namespace MoutsOrder.WebApi.Mappings;

public class CreateOrderItemRequestProfile : Profile
{
    public CreateOrderItemRequestProfile()
    {
        CreateMap<CreateOrderItemRequest, CreateOrderItemCommand>();
    }
}