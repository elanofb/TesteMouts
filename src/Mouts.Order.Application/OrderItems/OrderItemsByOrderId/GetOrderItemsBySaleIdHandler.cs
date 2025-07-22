using AutoMapper;
using MediatR;
using MoutsOrder.Domain.Repositories;
namespace MoutsOrder.Application.OrderItems.GetOrderItemsByOrderId;

public class GetOrderItemsByOrderIdHandler : IRequestHandler<GetOrderItemsByOrderIdCommand, List<GetOrderItemsByOrderIdResult>>
{
    private readonly IOrderItemRepository _repo;
    private readonly IMapper _mapper;

    public GetOrderItemsByOrderIdHandler(IOrderItemRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<GetOrderItemsByOrderIdResult>> Handle(GetOrderItemsByOrderIdCommand request, CancellationToken cancellationToken)
    {
        var orderItems = await _repo.GetByOrderIdAsync(request.OrderId);
        return _mapper.Map<List<GetOrderItemsByOrderIdResult>>(orderItems);
    }
}
