using MediatR;

namespace MoutsOrder.Application.OrderItems.GetOrderItem;

/// <summary>
/// Command for retrieving a orderitem by their ID
/// </summary>
public record GetOrderItemCommand : IRequest<GetOrderItemResult>
{
    /// <summary>
    /// The unique identifier of the orderitem to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetOrderItemCommand
    /// </summary>
    /// <param name="id">The ID of the orderitem to retrieve</param>
    public GetOrderItemCommand(Guid id)
    {
        Id = id;
    }
}
