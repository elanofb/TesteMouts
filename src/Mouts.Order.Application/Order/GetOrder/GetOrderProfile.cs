using AutoMapper;
using MoutsOrder.Domain.Entities;

namespace MoutsOrder.Application.Orders.GetOrder;

/// <summary>
/// Profile for mapping between Order entity and GetOrderResponse
/// </summary>
public class GetOrderProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetOrder operation
    /// </summary>
    public GetOrderProfile()
    {
        CreateMap<Order, GetOrderResult>();
    }
}
