using AutoMapper;
using MoutsOrder.Application.OrderItems.CreateOrderItem;
using MoutsOrder.Domain.Entities;

namespace MoutsOrder.WebApi.Features.OrderItems.CreateOrderItems;

/// <summary>
/// Profile for mapping between Application and API CreateOrder responses
/// </summary>
public class CreateOrderItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateOrder feature
    /// </summary>
    public CreateOrderItemProfile()
    {
        CreateMap<CreateOrderItemRequest, CreateOrderItemCommand>();
        CreateMap<CreateOrderItemResult, CreateOrderItemResponse>();
         
        CreateMap<OrderItem, CreateOrderItemResult>();
    }
}
