using MediatR;
using FluentValidation;
using MoutsOrder.Domain.Repositories;
using MoutsOrder.Domain.Events;
using MoutsOrder.Domain.Services;

namespace MoutsOrder.Application.OrderItems.DeleteOrderItem;

/// <summary>
/// Handler for processing DeleteOrderItemCommand requests
/// </summary>
public class DeleteOrderItemHandler : IRequestHandler<DeleteOrderItemCommand, DeleteOrderItemResponse>
{
    private readonly IOrderItemRepository _orderitemRepository;
    private readonly IMessageBusService _messageBusService;

    /// <summary>
    /// Initializes a new instance of DeleteOrderItemHandler
    /// </summary>
    /// <param name="orderitemRepository">The orderitem repository</param>
    /// <param name="validator">The validator for DeleteOrderItemCommand</param>
    public DeleteOrderItemHandler(
        IOrderItemRepository orderitemRepository, IMessageBusService messageBusService)
    {
        _orderitemRepository = orderitemRepository;
        _messageBusService = messageBusService;
    }

    /// <summary>
    /// Handles the DeleteOrderItemCommand request
    /// </summary>
    /// <param name="request">The DeleteOrderItem command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteOrderItemResponse> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteOrderItemValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _orderitemRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"OrderItem with ID {request.Id} not found");

        // Publicando evento no Rebus ap�s cancelar item da venda.
        await _messageBusService.PublishEvent(new ItemCanceledEvent(request.Id.ToString()));

        return new DeleteOrderItemResponse { Success = true };
    }
}
