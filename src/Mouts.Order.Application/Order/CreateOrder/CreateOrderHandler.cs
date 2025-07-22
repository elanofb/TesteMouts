using AutoMapper;
using MediatR;
using FluentValidation;
using MoutsOrder.Domain.Repositories;
using MoutsOrder.Domain.Entities;
using MoutsOrder.Common.Security;
using MoutsOrder.ORM.Repositories;
using MoutsOrder.Domain.Events;
using System.Threading;
using System.Threading.Tasks;
using MoutsOrder.Domain.Services;
using Microsoft.Extensions.Logging;

namespace MoutsOrder.Application.Orders.CreateOrder;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, CreateOrderResult>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMessageBusService _messageBusService;
    //private readonly OrderDiscountService _discountService;
    private readonly ILogger<CreateOrderHandler> _logger;

    public CreateOrderHandler(IOrderRepository orderRepository,
                                IMapper mapper,
                                IOrderItemRepository orderItemRepository,
                                IMessageBusService messageBusService,
                                //OrderDiscountService discountService,
                                ILogger<CreateOrderHandler> logger)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _orderItemRepository = orderItemRepository;
        _messageBusService = messageBusService;
        //_discountService = discountService;
        _logger = logger;
    }

    public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Starting order creation for command {@Command}", command);

            var validator = new CreateOrderCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid){
                _logger.LogWarning("Validation failed for order command: {@ValidationErrors}", validationResult.Errors);
                throw new ValidationException(validationResult.Errors);
            }

            var existingOrder = await _orderRepository.GetByIdAsync(command.Id, cancellationToken);
            if (existingOrder != null){
                _logger.LogWarning("Attempted to create duplicate order with ID {OrderId}", command.Id);
                throw new InvalidOperationException($"Order with ID {command.Id} already exists");
            }

            // Busca o último ID de venda 
            //var lastOrder = await _orderRepository.GetLastIdAsync(cancellationToken);            
            //var nextOrderId = lastOrder + 1;

            var order = _mapper.Map<Order>(command);
            //order.Id = nextOrderId;
            order.Id = new Guid();

            //_logger.LogInformation("Applying discounts for order {OrderId}", order.Id);
            // Aplicar desconto antes de salvar a venda
            //l_discountService.ApplyDiscounts(order.Items);

            order.CreatedAt = DateTime.SpecifyKind(order.CreatedAt, DateTimeKind.Utc);

            var createdOrder = await _orderRepository.CreateAsync(order, cancellationToken);
            _logger.LogInformation("Order created successfully with ID {OrderId}", createdOrder.Id);

            // Publicando evento no Rebus após salvar a venda.
            await _messageBusService.PublishEvent(new OrderCreatedEvent(createdOrder.Id.ToString(), createdOrder.Customer, createdOrder.ExternalId, createdOrder.TotalValue));
            _logger.LogInformation("Order created event published for order {OrderId}", createdOrder.Id);

            var result = _mapper.Map<CreateOrderResult>(createdOrder);

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating order for command {@Command}", command);
            throw;
        }
    }
}
