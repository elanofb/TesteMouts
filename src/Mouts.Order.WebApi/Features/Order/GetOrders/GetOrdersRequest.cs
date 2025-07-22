namespace MoutsOrder.WebApi.Features.Orders.GetOrders
{
    public class GetOrdersRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
