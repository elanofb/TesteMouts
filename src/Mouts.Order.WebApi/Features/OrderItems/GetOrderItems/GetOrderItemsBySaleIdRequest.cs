using MediatR;
using MoutsOrder.Application.OrderItems.GetOrderItemsByOrderId;

namespace MoutsOrder.WebApi.Features.OrderItems.GetOrderItemsByOrderId;

public class GetOrderItemsByOrderIdRequest : IRequest<List<GetOrderItemsByOrderIdResult>>
{
    public int OrderId { get; set; }
}
