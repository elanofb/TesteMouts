using AutoMapper;
using MediatR;
using FluentValidation;
using MoutsOrder.Domain.Repositories;
using MoutsOrder.Domain.Entities;
using MoutsOrder.Common.Security;

namespace MoutsOrder.Application.OrderItems.CreateOrderItem;

/// <summary>
/// Handler for processing CreateOrderItemCommand requests
/// </summary>
public class CreateOrderItemHandler : IRequestHandler<CreateOrderItemCommand, CreateOrderItemResult>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderitemRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    public CreateOrderItemHandler(IOrderItemRepository orderitemRepository, IOrderRepository orderRepository, IMapper mapper)
    {
        _orderitemRepository = orderitemRepository;
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<CreateOrderItemResult> Handle(CreateOrderItemCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateOrderItemCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingOrder = await _orderRepository.GetByIdAsync(command.OrderId, cancellationToken);
        if (existingOrder == null)
            throw new InvalidOperationException($"Order with ID {command.OrderId} doesn't exists");

        var orderitem = _mapper.Map<OrderItem>(command);

        var createdOrderItem = await _orderitemRepository.CreateAsync(orderitem, cancellationToken);
        var result = _mapper.Map<CreateOrderItemResult>(createdOrderItem);
        return result;
    }
}
