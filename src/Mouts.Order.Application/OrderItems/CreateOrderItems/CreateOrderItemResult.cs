namespace MoutsOrder.Application.OrderItems.CreateOrderItem;

/// <summary>
/// Represents the response returned after successfully creating a new orderitem.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created orderitem,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateOrderItemResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created orderitem.
    /// </summary>
    /// <value>A GUID that uniquely identifies the created orderitem in the system.</value>
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal Total { get; set; }
}
