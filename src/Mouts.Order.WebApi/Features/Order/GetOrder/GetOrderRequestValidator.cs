using FluentValidation;

namespace MoutsOrder.WebApi.Features.Orders.GetOrder;

/// <summary>
/// Validator for GetOrderRequest
/// </summary>
public class GetOrderRequestValidator : AbstractValidator<GetOrderRequest>
{
    /// <summary>
    /// Initializes validation rules for GetOrderRequest
    /// </summary>
    public GetOrderRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Order ID is required");
    }
}
