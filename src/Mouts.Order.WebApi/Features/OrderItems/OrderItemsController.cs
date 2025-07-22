using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MoutsOrder.WebApi.Common;
using MoutsOrder.Application.OrderItems.GetOrderItemsByOrderId;
using MoutsOrder.WebApi.Features.OrderItems.GetOrderItemsByOrderId;
using MoutsOrder.Application.OrderItems.DeleteOrderItem;
using MoutsOrder.Application.OrderItems.CreateOrderItem;
using MoutsOrder.WebApi.Features.OrderItems.CreateOrderItems;

namespace MoutsOrder.WebApi.Features.Orders;

/// <summary>
/// Controller for managing order operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class OrderItemController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    
    public OrderItemController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
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
            Message = "Items retrieved",
            Data = result
        });
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateOrderItemResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Post(CreateOrderItemRequest request, CancellationToken ct)
    {
        var command = _mapper.Map<CreateOrderItemCommand>(request);
        var result = await _mediator.Send(command, ct);
        var response = _mapper.Map<CreateOrderItemResponse>(result);

        return Ok(new ApiResponseWithData<CreateOrderItemResponse>
        {
            Success = true,
            Message = "Item created successfully",
            Data = response
        });
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var command = new DeleteOrderItemCommand(id); // Use o construtor aqui
        await _mediator.Send(command, ct);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Item deleted successfully"
        });
    }

}
