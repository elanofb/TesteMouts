using AutoMapper;
using MoutsOrder.Domain.Entities;

namespace MoutsOrder.Application.Products.GetProduct;

public class GetProductProfile : Profile
{
    public GetProductProfile()
    {
        CreateMap<Product, GetProductResult>();
    }
}
