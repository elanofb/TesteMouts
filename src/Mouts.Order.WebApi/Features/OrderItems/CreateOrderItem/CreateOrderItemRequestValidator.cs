using MoutsOrder.Domain.Enums;
using MoutsOrder.Domain.Validation;
using FluentValidation;

namespace MoutsOrder.WebApi.Features.OrderItems.CreateOrderItems;

/// <summary>
/// Validator for CreateOrderRequest that defines validation rules for order creation.
/// </summary>
public class CreateOrderItemRequestValidator : AbstractValidator<CreateOrderItemRequest>
{
    public CreateOrderItemRequestValidator()    {
    }
}