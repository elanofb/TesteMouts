namespace MoutsOrder.Domain.Entities
{  
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = new Order();
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        //public int Id { get; set; } // EF Core irá configurar como Identity
        //public int OrderId { get; set; }
        //public int ProductId { get; set; }
        //public int Quantity { get; set; }
        //public decimal UnitPrice { get; set; }
        //public decimal Discount { get; set; }
        //public decimal Total { get; set; }
        //public Product Product { get; set; }
        //public Order Order { get; set; }
    }
}