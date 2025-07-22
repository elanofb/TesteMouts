using MoutsOrder.Domain.Enums;
using MoutsOrder.Domain.Entities;
using MoutsOrder.WebApi.Features.OrderItems.CreateOrderItems;

namespace MoutsOrder.WebApi.Features.Orders.CreateOrder;

/// <summary>
/// Represents a request to create a new order in the system.
/// </summary>
public class CreateOrderRequest
{
    //public int Id { get; set; }
    public Guid ProductId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Customer { get; set; }
    public string ExternalId { get; set; }   
    public decimal TotalValue { get; set; }
    //public List<OrderItem> Items { get; set; } = new();
    public List<OrderItemCreateRequest> Items { get; set; } = new();
}

public class OrderItemCreateRequest
{
    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}