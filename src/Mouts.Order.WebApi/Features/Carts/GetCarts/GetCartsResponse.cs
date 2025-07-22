using MoutsOrder.WebApi.Features.Carts.GetCart;

namespace MoutsOrder.WebApi.Features.Carts.GetCarts
{
    public class GetCartsResponse
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<GetCartResponse> Data { get; set; } = new();
    }
}
