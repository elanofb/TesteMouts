using MoutsOrder.Domain.Enums;
using MoutsOrder.Domain.Validation;
using FluentValidation;

namespace MoutsOrder.Application.OrderItems.CreateOrderItem;

/// <summary>
/// Validator for CreateOrderItemCommand that defines validation rules for orderitem creation command.
/// </summary>
public class CreateOrderItemCommandValidator : AbstractValidator<CreateOrderItemCommand>
{
    public CreateOrderItemCommandValidator()
    {
        RuleFor(x => x.OrderId).NotNull().NotEmpty();
        RuleFor(x => x.ProductId).NotNull().NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
    }
}