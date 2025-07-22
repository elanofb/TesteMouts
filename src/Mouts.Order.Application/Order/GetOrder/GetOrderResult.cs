using MoutsOrder.Domain.Entities;

namespace MoutsOrder.Application.Orders.GetOrder;

/// <summary>
/// Response model for GetOrder operation
/// </summary>
public class GetOrderResult
{
    //public Guid Id { get; set; }
    //public string OrderNumber { get; set; }
    //public DateTime OrderDate { get; set; }
    //public string Customer { get; set; }
    //public decimal TotalAmount { get; set; }
    //public string Branch { get; set; }
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Customer { get; set; }
    public string ExternalId { get; set; }
    public decimal TotalAmount { get; set; }
    public List<OrderItem> Items { get; set; } = new();
}
