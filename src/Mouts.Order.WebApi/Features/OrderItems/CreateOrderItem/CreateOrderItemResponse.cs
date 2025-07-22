using MoutsOrder.Domain.Enums;

namespace MoutsOrder.WebApi.Features.OrderItems.CreateOrderItems;

public class CreateOrderItemResponse
{
    //public int Id { get; set; }    
    //public int OrderId { get; set; }
    //public int ProductId { get; set; }
    //public int Quantity { get; set; }
    //public decimal UnitPrice { get; set; }
    //public decimal Discount { get; set; }
    //public decimal Total { get; set; }
    public string Id { get; set; }
    public string OrderId { get; set; }
    public string ProductId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
