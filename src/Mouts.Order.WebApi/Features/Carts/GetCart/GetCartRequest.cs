using MediatR;

namespace MoutsOrder.WebApi.Features.Carts.GetCart
{
    public class GetCartRequest : IRequest<GetCartResponse>
    {
        public int Id { get; set; }
    }
}
