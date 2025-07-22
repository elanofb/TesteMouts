using MoutsOrder.Domain.Enums;
using MoutsOrder.Domain.Validation;
using FluentValidation;

namespace MoutsOrder.WebApi.Features.Orders.CreateOrder;

/// <summary>
/// Validator for CreateOrderRequest that defines validation rules for order creation.
/// </summary>
public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator()
    {
        //RuleFor(x => x.Id)
        //    .NotEmpty()
        //    .WithMessage("Order number is required.");

        RuleFor(x => x.CreatedAt)
            .NotEmpty()
            .WithMessage("Order date is required.");

        RuleFor(x => x.Customer)
            .NotEmpty()
            .WithMessage("Customer name is required.");

        //RuleFor(x => x.TotalAmount)
        //    .GreaterThan(0)
        //    .WithMessage("Total amount must be greater than zero.");

        //RuleFor(x => x.Customer)
        //    .NotEmpty()
        //    .WithMessage("Branch is required.");
    }
}