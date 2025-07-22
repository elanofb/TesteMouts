using MoutsOrder.Application.Products.GetProduct;

namespace MoutsOrder.Application.Products.GetProducts
{
    public class GetProductsResult
    {
        public List<GetProductResult> Products { get; set; } = new();
    }
}
