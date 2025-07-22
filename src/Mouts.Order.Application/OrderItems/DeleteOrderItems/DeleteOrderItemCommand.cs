using MediatR;

namespace MoutsOrder.Application.OrderItems.DeleteOrderItem;

/// <summary>
/// Command for deleting a orderitem
/// </summary>
public record DeleteOrderItemCommand : IRequest<DeleteOrderItemResponse>
{
    /// <summary>
    /// The unique identifier of the orderitem to delete
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteOrderItemCommand
    /// </summary>
    /// <param name="id">The ID of the orderitem to delete</param>
    public DeleteOrderItemCommand(Guid id)
    {
        Id = id;
    }
}
