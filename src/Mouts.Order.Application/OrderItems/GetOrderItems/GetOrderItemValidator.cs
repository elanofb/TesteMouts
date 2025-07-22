using FluentValidation;

namespace MoutsOrder.Application.OrderItems.GetOrderItem;

/// <summary>
/// Validator for GetOrderItemCommand
/// </summary>
public class GetOrderItemValidator : AbstractValidator<GetOrderItemCommand>
{
    /// <summary>
    /// Initializes validation rules for GetOrderItemCommand
    /// </summary>
    public GetOrderItemValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Order Item ID is required");
    }
}
