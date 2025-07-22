namespace MoutsOrder.Domain.Events
{
    public class OrderCreatedEvent
    {
        public string OrderId { get; set; }
        public string Customer { get; set; }
        public string ExternalId { get; set; }
        public decimal TotalValue { get; set; }

        public OrderCreatedEvent(string orderId, string customer, string externalId, decimal totalValue)
        {
            OrderId = orderId;
            Customer = customer;
            ExternalId = externalId;
            TotalValue = totalValue;
        }
    }
}
