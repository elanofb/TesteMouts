using System;

namespace MoutsOrder.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }

         // public string Description { get; set; } = string.Empty;
        // public bool IsAvailable { get; set; }
        // public decimal UnitPrice;
        // public ICollection<OrderItem> OrderItems { get; set; }

        // public ICollection<OrderItem> OrderItems { get; set; }
    }
}
