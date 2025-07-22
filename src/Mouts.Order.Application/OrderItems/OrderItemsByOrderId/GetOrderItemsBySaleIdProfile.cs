using AutoMapper;

namespace MoutsOrder.Application.OrderItems.GetOrderItemsByOrderId;

public class GetOrderItemsByOrderIdProfile : Profile
{
    public GetOrderItemsByOrderIdProfile()
    {
        CreateMap<Domain.Entities.OrderItem, GetOrderItemsByOrderIdResult>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

    }
}
