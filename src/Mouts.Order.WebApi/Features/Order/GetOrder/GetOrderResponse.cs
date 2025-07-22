using MoutsOrder.Domain.Enums;
using MoutsOrder.Domain.Entities;

namespace MoutsOrder.WebApi.Features.Orders.GetOrder;

public class GetOrderResponse
{
    //public int Id { get; set; }
    //public string OrderNumber { get; set; }
    //public DateTime OrderDate { get; set; }
    //public string Customer { get; set; }
    //public decimal TotalAmount { get; set; }
    //public string Branch { get; set; }
    public Guid Id { get; set; }
    public string? ExternalId { get; set; } // ID do sistema A
    public string Customer { get; set; }
    public decimal TotalValue { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<OrderItem> Items { get; set; } = new();

}
