using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MoutsOrder.WebApi.Common;
using MoutsOrder.WebApi.Features.Orders.CreateOrder;
using MoutsOrder.WebApi.Features.Orders.GetOrder;
using MoutsOrder.WebApi.Features.Orders.DeleteOrder;
using MoutsOrder.Application.Orders.CreateOrder;
using MoutsOrder.Application.Orders.GetOrder;
using MoutsOrder.Application.Orders.DeleteOrder;
using MoutsOrder.Application.Orders.GetOrders;
using MoutsOrder.Application.OrderItems.GetOrderItemsByOrderId;
using MoutsOrder.WebApi.Features.Orders.GetOrders;
using MoutsOrder.WebApi.Features.OrderItems.GetOrderItemsByOrderId;

namespace MoutsOrder.WebApi.Features.Orders;

/// <summary>
/// Controller for managing order operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class OrdersController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    
    public OrdersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new order
    /// </summary>
    /// <param name="request">The order creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created order details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateOrderResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateOrderRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateOrderCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateOrderResponse>
        {
            Success = true,
            Message = "Order created successfully",
            Data = _mapper.Map<CreateOrderResponse>(response)
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders([FromQuery] GetOrdersRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<GetOrdersCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetOrdersResponse>
        {
            Success = true,
            Message = "Orders retrieved successfully",
            Data = _mapper.Map<GetOrdersResponse>(response)
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetOrderResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOrder([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetOrderRequest { Id = id };
        var validator = new GetOrderRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetOrderCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetOrderResponse>
        {
            Success = true,
            Message = "Order retrieved successfully",
            Data = _mapper.Map<GetOrderResponse>(response)
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteOrder([FromRoute] int id, CancellationToken cancellationToken)
    {
        var request = new DeleteOrderRequest { Id = id };
        var validator = new DeleteOrderRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteOrderCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Order deleted successfully"
        });
    }

    [HttpGet("{orderId}/items")]
    [ProducesResponseType(typeof(ApiResponseWithData<List<GetOrderItemsByOrderIdResult>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOrderItemsByOrderId(int orderId, CancellationToken ct)
    {
        var request = new GetOrderItemsByOrderIdRequest { OrderId = orderId };
        var command = _mapper.Map<GetOrderItemsByOrderIdCommand>(request);
        var result = await _mediator.Send(command, ct);

        return Ok(new ApiResponseWithData<List<GetOrderItemsByOrderIdResult>>
        {
            Success = true,
            Message = "Order items retrieved",
            Data = result
        });
    }   

}
