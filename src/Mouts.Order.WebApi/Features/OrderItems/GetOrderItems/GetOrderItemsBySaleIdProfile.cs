using AutoMapper;
using MoutsOrder.Application.OrderItems.GetOrderItemsByOrderId;

namespace MoutsOrder.WebApi.Features.OrderItems.GetOrderItemsByOrderId;

public class GetOrderItemsByOrderIdProfile : Profile
{
    public GetOrderItemsByOrderIdProfile()
    {
        CreateMap<GetOrderItemsByOrderIdRequest, GetOrderItemsByOrderIdCommand>();
    }
}
