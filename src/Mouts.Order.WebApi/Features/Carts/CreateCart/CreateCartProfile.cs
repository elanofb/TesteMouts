using AutoMapper;
using MoutsOrder.WebApi.Features.Carts.CreateCart;
using MoutsOrder.Application.Carts.CreateCart;
using MoutsOrder.Domain.Entities;

namespace MoutsOrder.WebApi.Features.Carts.CreateCart
{
    public class CreateCartProfile : Profile
    {
        public CreateCartProfile()
        {
            CreateMap<CreateCartRequest, CreateCartCommand>();
            CreateMap<CreateCartProductRequest, CartProduct>();
            CreateMap<CreateCartResult, CreateCartResponse>();
            CreateMap<CartProduct, CreateCartProductResponse>();
            CreateMap<CreateCartCommand, Cart>();
            CreateMap<Cart, CreateCartResult>();
        }
    }
}
