using FluentValidation;

namespace MoutsOrder.Application.OrderItems.DeleteOrderItem;

/// <summary>
/// Validator for DeleteOrderItemCommand
/// </summary>
public class DeleteOrderItemValidator : AbstractValidator<DeleteOrderItemCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteOrderItemCommand
    /// </summary>
    public DeleteOrderItemValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().NotEmpty()
            .WithMessage("Id must not be null or empty.");
    }
}
