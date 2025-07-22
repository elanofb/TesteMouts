using MoutsOrder.Application.OrderItems.DeleteOrderItem;
using AutoMapper;

namespace MoutsOrder.WebApi.Features.OrderItems.DeleteOrderItem;

public class DeleteOrderItemProfile : Profile
{
    public DeleteOrderItemProfile()
    {
        CreateMap<DeleteOrderItemRequest, DeleteOrderItemCommand>();
    }
}
