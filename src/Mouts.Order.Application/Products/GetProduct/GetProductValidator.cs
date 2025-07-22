using FluentValidation;

namespace MoutsOrder.Application.Products.GetProduct;

public class GetProductValidator : AbstractValidator<GetProductCommand>
{
    public GetProductValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Product ID is required");
    }
}
