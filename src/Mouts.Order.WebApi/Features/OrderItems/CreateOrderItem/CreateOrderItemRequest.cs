using MoutsOrder.Domain.Enums;
using MoutsOrder.Domain.Entities;

namespace MoutsOrder.WebApi.Features.OrderItems.CreateOrderItems;

/// <summary>
/// Represents a request to create a new order in the system.
/// </summary>
public class CreateOrderItemRequest
{
    //public int OrderId { get; set; }
    //public int ProductId { get; set; }
    //public int Quantity { get; set; }
    //public decimal UnitPrice { get; set; }
    //public decimal Discount { get; set; }
    
    public string OrderId { get; set; }
    public string ProductId { get; set; }
    //public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}