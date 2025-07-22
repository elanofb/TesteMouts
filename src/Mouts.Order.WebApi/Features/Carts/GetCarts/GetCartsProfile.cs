using AutoMapper;
using MoutsOrder.Application.Carts.GetCart;
using MoutsOrder.Application.Carts.GetCarts;
using MoutsOrder.WebApi.Features.Carts.GetCart;

namespace MoutsOrder.WebApi.Features.Carts.GetCarts
{
    public class GetCartsProfile : Profile
    {
        public GetCartsProfile()
        {
            CreateMap<GetCartsResult, GetCartsResponse>();
            CreateMap<GetCartResult, GetCartResponse>();
            CreateMap<GetCartsRequest, GetCartsCommand>();
            CreateMap<GetCartsResult, GetCartsResponse>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data));
        }
    }
}
