namespace MoutsOrder.WebApi.Features.Orders.GetOrder;

/// <summary>
/// Request model for getting a order by ID
/// </summary>
public class GetOrderRequest
{
    /// <summary>
    /// The unique identifier of the order to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
