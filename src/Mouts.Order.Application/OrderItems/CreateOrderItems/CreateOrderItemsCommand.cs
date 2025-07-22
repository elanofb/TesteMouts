using MoutsOrder.Common.Validation;
using MoutsOrder.Domain.Enums;
using MoutsOrder.Domain.Entities;
using MediatR;

namespace MoutsOrder.Application.OrderItems.CreateOrderItem;

public class CreateOrderItemCommand : IRequest<CreateOrderItemResult>
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    //public int OrderId { get; set; }
    //public int ProductId { get; set; }
    //public int Quantity { get; set; }
    //public decimal UnitPrice { get; set; }
    //public decimal Discount { get; set; }
    //public decimal Total => (UnitPrice * Quantity) - Discount;
}