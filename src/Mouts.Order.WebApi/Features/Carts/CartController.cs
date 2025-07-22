using MoutsOrder.WebApi.Features.Carts.CreateCart;
using MoutsOrder.WebApi.Features.Carts.GetCart;
using MoutsOrder.WebApi.Features.Carts.GetCarts;
using MoutsOrder.WebApi.Features.Carts.UpdateCart;
using MoutsOrder.WebApi.Features.Carts.DeleteCart;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using MoutsOrder.WebApi.Common;
using MoutsOrder.Application.Carts.CreateCart;
using AutoMapper;
using MoutsOrder.Application.Orders.CreateOrder;
using MoutsOrder.WebApi.Features.Orders.CreateOrder;
using System.Threading;
using MoutsOrder.Application.Orders.GetOrder;
using MoutsOrder.WebApi.Features.Orders.GetOrder;
using MoutsOrder.Application.Carts.GetCart;
using MoutsOrder.Application.Orders.GetOrders;
using MoutsOrder.WebApi.Features.Orders.GetOrders;
using MoutsOrder.Application.Carts.GetCarts;

namespace MoutsOrder.WebApi.Features.Carts
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CartController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateCartResponse>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateCartRequest request, CancellationToken ct)
        {
          
            var validator = new CreateCartRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateCartCommand>(request);
            var response = await _mediator.Send(command);

            return Created(string.Empty, new ApiResponseWithData<CreateCartResponse>
            {
                Success = true,
                Message = "Item adicionado ao carrinho",
                Data = _mapper.Map<CreateCartResponse>(response)
            });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetCartResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var request = new GetCartRequest { Id = id };
            var command = _mapper.Map<GetCartCommand>(request.Id);

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = $"Cart with ID {id} not found"
                });

            return Ok(new ApiResponseWithData<GetCartResponse>
            {
                Success = true,
                Message = "Cart found",
                Data = _mapper.Map<GetCartResponse>(result)
            });

        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseWithData<PaginatedResponse<GetCartsResponse>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetCartsRequest request, CancellationToken ct)
        {
            var command = _mapper.Map<GetCartsCommand>(request);
            var response = await _mediator.Send(command);

            return Ok(new ApiResponseWithData<GetCartsResponse>
            {
                Success = true,
                Message = "Carts retrieved successfully",
                Data = _mapper.Map<GetCartsResponse>(response)
            });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<UpdateCartResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCartRequest request, CancellationToken ct)
        {
            request.Id = id;
            var result = await _mediator.Send(request, ct);
            return Ok(new ApiResponseWithData<UpdateCartResponse>
            {
                Success = true,
                Message = "Cart updated",
                Data = (UpdateCartResponse)result
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            await _mediator.Send(new DeleteCartRequest { Id = id }, ct);
            return NoContent();
        }
    }
}
