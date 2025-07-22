using AutoMapper;
using MediatR;
using FluentValidation;
using MoutsOrder.Domain.Repositories;

namespace MoutsOrder.Application.OrderItems.GetOrderItem;

/// <summary>
/// Handler for processing GetOrderItemCommand requests
/// </summary>
public class GetOrderItemHandler : IRequestHandler<GetOrderItemCommand, GetOrderItemResult>
{
    private readonly IOrderItemRepository _orderitemRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetOrderItemHandler
    /// </summary>
    /// <param name="orderitemRepository">The orderitem repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetOrderItemCommand</param>
    public GetOrderItemHandler(
        IOrderItemRepository orderitemRepository,
        IMapper mapper)
    {
        _orderitemRepository = orderitemRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetOrderItemCommand request
    /// </summary>
    /// <param name="request">The GetOrderItem command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The orderitem details if found</returns>
    public async Task<GetOrderItemResult> Handle(GetOrderItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetOrderItemValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var orderitem = await _orderitemRepository.GetByIdAsync(request.Id, cancellationToken);
        if (orderitem == null)
            throw new KeyNotFoundException($"OrderItem with ID {request.Id} not found");

        return _mapper.Map<GetOrderItemResult>(orderitem);
    }
}
