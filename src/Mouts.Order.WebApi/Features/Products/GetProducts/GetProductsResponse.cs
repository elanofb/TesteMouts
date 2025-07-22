using MoutsOrder.WebApi.Features.Products.GetProduct;

namespace MoutsOrder.WebApi.Features.Products.GetProducts
{
    public class GetProductsResponse
    {
        public List<GetProductResponse> Products { get; set; } = new();
    }
}
