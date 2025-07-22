using AutoMapper;
using MoutsOrder.Domain.Entities;

namespace MoutsOrder.Application.OrderItems.GetOrderItem;

/// <summary>
/// Profile for mapping between OrderItem entity and GetOrderItemResponse
/// </summary>
public class GetOrderItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetOrderItem operation
    /// </summary>
    public GetOrderItemProfile()
    {
        CreateMap<OrderItem, GetOrderItemResult>();
    }
}
