using MediatR;
using FluentValidation;
using MoutsOrder.Domain.Repositories;

namespace MoutsOrder.Application.Products.DeleteProduct;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductHandler(
        IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteProductValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _productRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Product with ID {request.Id} not found");

        return new DeleteProductResponse { Success = true };
    }
}
