using AutoMapper;
using MoutsOrder.Application.Products.GetProducts;

namespace MoutsOrder.WebApi.Features.Products.GetProducts
{
    public class GetProductsProfile : Profile
    {
        public GetProductsProfile()
        {
            CreateMap<GetProductsRequest, GetProductsCommand>();
            CreateMap<GetProductsResult, GetProductsResponse>();
        }
    }
}
