using AutoMapper;
using MoutsOrder.Application.Carts.UpdateCart;

namespace MoutsOrder.WebApi.Features.Carts.UpdateCart
{
    public class UpdateCartProfile : Profile
    {
        public UpdateCartProfile()
        {
            CreateMap<UpdateCartRequest, UpdateCartCommand>();
            CreateMap<UpdateCartResult, UpdateCartResponse>();
            CreateMap<CartProduct, UpdateCartProductResponse>();
        }
    }
}
