using AutoMapper;
using MoutsOrder.Domain.Entities;

namespace MoutsOrder.Application.Products.CreateProduct;

public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        CreateMap<CreateProductCommand, Product>();
        CreateMap<Product, CreateProductResult>();
    }
}
