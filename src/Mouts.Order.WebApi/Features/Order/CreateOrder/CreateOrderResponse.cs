using MoutsOrder.Domain.Enums;

namespace MoutsOrder.WebApi.Features.Orders.CreateOrder;

public class CreateOrderResponse
{
    public Guid Id { get; set; }    
    public string Customer { get; set; }
    public string ExternalId { get; set; }
}
