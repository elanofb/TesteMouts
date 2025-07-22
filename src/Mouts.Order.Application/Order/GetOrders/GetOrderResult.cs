using MoutsOrder.Application.Orders.GetOrder;

namespace MoutsOrder.Application.Orders.GetOrders
{
    public class GetOrdersResult
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<GetOrderResult> Orders { get; set; } = new();
    }
}
