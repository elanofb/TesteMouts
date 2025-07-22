using MoutsOrder.WebApi.Features.Carts.GetCart;
using MediatR;

namespace MoutsOrder.WebApi.Features.Carts.GetCarts
{
    public class GetCartsRequest : IRequest<GetCartsResponse>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Order { get; set; } = "id asc";
    }
}
