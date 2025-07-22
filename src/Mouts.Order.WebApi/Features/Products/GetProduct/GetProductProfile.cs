using AutoMapper;

using MoutsOrder.Application.Products.GetProduct;
namespace MoutsOrder.WebApi.Features.Products.GetProduct;

public class GetProductProfile : Profile
{
    public GetProductProfile()
    {
        CreateMap<Guid, GetProductCommand>()
            .ConstructUsing(id => new GetProductCommand(id));

        CreateMap<GetProductResult, GetProductResponse>();
    }
}
