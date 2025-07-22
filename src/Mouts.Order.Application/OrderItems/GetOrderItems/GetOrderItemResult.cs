using MoutsOrder.Domain.Enums;
using MoutsOrder.Domain.Entities;

namespace MoutsOrder.Application.OrderItems.GetOrderItem;

/// <summary>
/// Response model for GetOrderItem operation
/// </summary>
public class GetOrderItemResult
{
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
}
