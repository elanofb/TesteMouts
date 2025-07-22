using AutoMapper;
using MoutsOrder.Domain.Entities;

namespace MoutsOrder.Application.OrderItems.CreateOrderItem;

/// <summary>
/// Profile for mapping between OrderItem entity and CreateOrderItemResponse
/// </summary>
public class CreateOrderItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateOrderItem operation
    /// </summary>
    public CreateOrderItemProfile()
    {
        CreateMap<CreateOrderItemCommand, OrderItem>();
        CreateMap<OrderItem, CreateOrderItemResult>();
    }
}
