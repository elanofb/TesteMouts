using MediatR;

namespace MoutsOrder.Application.Orders.GetOrders
{
    public class GetOrdersCommand : IRequest<GetOrdersResult>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
