﻿using MoutsOrder.Domain.Enums;
using MoutsOrder.Domain.Validation;
using FluentValidation;

namespace MoutsOrder.Application.Products.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
                   .NotEmpty()
                   .WithMessage("Name is required");

        RuleFor(x => x.UnitPrice)
            .GreaterThan(0)
            .WithMessage("Price must be greater than zero");
    }
}