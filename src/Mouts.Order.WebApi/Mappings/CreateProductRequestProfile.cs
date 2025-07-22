using MoutsOrder.Application.Products.CreateProduct;
using MoutsOrder.WebApi.Features.Products.CreateProduct;
using AutoMapper;

namespace MoutsOrder.WebApi.Mappings;

public class CreateProductRequestProfile : Profile
{
    public CreateProductRequestProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>();
    }
}