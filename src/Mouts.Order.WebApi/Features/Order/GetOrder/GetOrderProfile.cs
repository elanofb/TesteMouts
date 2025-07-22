using MoutsOrder.Application.Products.GetProduct;
using MoutsOrder.Application.Orders.GetOrder;
using MoutsOrder.WebApi.Features.Products.GetProduct;
using AutoMapper;

namespace MoutsOrder.WebApi.Features.Orders.GetOrder;

/// <summary>
/// Profile for mapping GetOrder feature requests to commands
/// </summary>
public class GetOrderProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetOrder feature
    /// </summary>
    public GetOrderProfile()
    {
        CreateMap<Guid, Application.Orders.GetOrder.GetOrderCommand>()
            .ConstructUsing(id => new Application.Orders.GetOrder.GetOrderCommand(id));

        CreateMap<GetOrderResult, GetOrderResponse>();
    }
}
