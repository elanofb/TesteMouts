using MoutsOrder.WebApi.Features.Orders.GetOrder;

namespace MoutsOrder.WebApi.Features.Orders.GetOrders
{
    public class GetOrdersResponse
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<GetOrderResponse> Orders { get; set; } = new();
    }
}
