using MoutsOrder.Domain.Enums;

namespace MoutsOrder.WebApi.Features.Products.GetProduct;

public class GetProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public bool IsAvailable { get; set; }

}
