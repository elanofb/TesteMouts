using AutoMapper;
using MoutsOrder.Application.Carts.DeleteCart;

namespace MoutsOrder.WebApi.Features.Carts.DeleteCart
{
    public class DeleteCartProfile : Profile
    {
        public DeleteCartProfile()
        {
            CreateMap<int, DeleteCartCommand>()
                .ConstructUsing(id => new DeleteCartCommand(id));
        }
    }
}
