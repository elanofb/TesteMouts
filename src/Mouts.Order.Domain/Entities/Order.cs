using MoutsOrder.Common.Security;
using MoutsOrder.Common.Validation;
using MoutsOrder.Domain.Common;
using MoutsOrder.Domain.Enums;
using MoutsOrder.Domain.Validation;

namespace MoutsOrder.Domain.Entities
{
    public class Order: BaseEntity//, IOrder
    {
        public Guid Id { get; set; }
        public string? ExternalId { get; set; } // ID do sistema A
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public string Customer { get; set; }
        public decimal TotalValue => Items?.Sum(i => i.Price * i.Quantity) ?? 0;
        public string Status { get; set; } = "RECEIVED"; // RECEIVED, PROCESSED, etc.
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        //public int Id { get; set; } // EF Core irá configurar como Identity
        //public string OrderNumber { get; set; }
        //public DateTime OrderDate { get; set; }
        //public string Customer { get; set; }
        //public decimal TotalAmount { get; set; }
        //public string Branch { get; set; }
        //public List<OrderItem> Items { get; set; } = new();
    }
}