using AutoMapper;
using MoutsOrder.Application.Orders.CreateOrder;
using MoutsOrder.Domain.Entities;
using MoutsOrder.WebApi.Features.OrderItems.CreateOrderItems;

namespace MoutsOrder.WebApi.Features.Orders.CreateOrder;

/// <summary>
/// Profile for mapping between Application and API CreateOrder responses
/// </summary>
public class CreateOrderProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateOrder feature
    /// </summary>
    public CreateOrderProfile()
    {
        CreateMap<CreateOrderRequest, CreateOrderCommand>();
        CreateMap<CreateOrderResult, CreateOrderResponse>();

        CreateMap<CreateOrderItemRequest, OrderItem>();
        CreateMap<CreateOrderCommand, Order>();

        CreateMap<OrderItemCreateRequest, OrderItem>(); 
    }
}
