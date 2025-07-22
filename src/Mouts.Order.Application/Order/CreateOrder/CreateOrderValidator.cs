using MoutsOrder.Domain.Enums;
using MoutsOrder.Domain.Validation;
using FluentValidation;
using MoutsOrder.Domain.Entities;

namespace MoutsOrder.Application.Orders.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateOrderCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - OrderNumber: Order Number is required.
    /// - TotalAmount: Total Amount must be greater than zero
    /// - OrderItems: A order must contain at least one OrderItem
    /// </remarks>
    public CreateOrderCommandValidator()
    {
        RuleFor(order => order.ProductId)
            .NotEmpty()
            .WithMessage("Product Id is required.");

        //RuleFor(order => order.TotalValue)
        //    .GreaterThan(0)
        //    .WithMessage("Total Value must be greater than zero.");

        RuleFor(order => order.Items)
            .NotEmpty()
            .WithMessage("A order must contain at least one OrderItem.");
    }
}