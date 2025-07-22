using MoutsOrder.Domain.Repositories;
using AutoMapper;
using MediatR;
using MoutsOrder.Application.Orders.GetOrder;

namespace MoutsOrder.Application.Orders.GetOrders
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersCommand, GetOrdersResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<GetOrdersResult> Handle(GetOrdersCommand request, CancellationToken cancellationToken)
        {
            var totalCount = await _orderRepository.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)request.PageSize);

            var orders = await _orderRepository.GetPagedAsync(request.Page, request.PageSize);
            var ordersResult = _mapper.Map<List<GetOrderResult>>(orders);

            return new GetOrdersResult
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                Page = request.Page,
                PageSize = request.PageSize,
                Orders = ordersResult
            };
        }
    }
}
