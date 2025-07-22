using MediatR;

namespace MoutsOrder.Application.OrderItems.GetOrderItemsByOrderId;

public class GetOrderItemsByOrderIdCommand : IRequest<List<GetOrderItemsByOrderIdResult>>
{
    public Guid OrderId { get; set; }
}
