using AutoMapper;
using MoutsOrder.Application.Orders.GetOrders;

namespace MoutsOrder.WebApi.Features.Orders.GetOrders
{
    public class GetOrdersProfile : Profile
    {
        public GetOrdersProfile()
        {
            CreateMap<GetOrdersRequest, GetOrdersCommand>();
            CreateMap<GetOrdersResult, GetOrdersResponse>();
        }
    }
}
