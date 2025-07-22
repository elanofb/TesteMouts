using MoutsOrder.Domain.Enums;

namespace MoutsOrder.Application.Products.GetProduct;

public class GetProductResult
{    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public bool IsAvailable { get; set; }
}
