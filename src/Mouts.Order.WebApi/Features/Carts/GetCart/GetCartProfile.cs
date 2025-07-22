using AutoMapper;
using MoutsOrder.Application.Carts.GetCart;

namespace MoutsOrder.WebApi.Features.Carts.GetCart
{
    public class GetCartProfile : Profile
    {
        public GetCartProfile()
        {
            CreateMap<GetCartResult, GetCartResponse>();
            CreateMap<CartProduct, GetCartProductResponse>();
            CreateMap<Cart, GetCartResult>();
            CreateMap<GetCartCommand, GetCartRequest>();
            CreateMap<Cart, GetCartResponse>();
        }
    }
}
