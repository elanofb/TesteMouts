using MediatR;
using MoutsOrder.Domain.Entities;
using MoutsOrder.ORM;
using AutoMapper;
using FluentValidation;
using MoutsOrder.Domain.Repositories;
using MoutsOrder.Common.Security;

namespace MoutsOrder.Application.Products.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateProductCommand> _validator;
        public CreateProductHandler(IProductRepository productRepository, 
                                    IMapper mapper,
                                    IValidator<CreateProductCommand> validator)
        {            
            _productRepository = productRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingProduct = await _productRepository.GetByIdAsync(command.Id, cancellationToken);
            if (existingProduct != null)
                throw new InvalidOperationException($"Product with ID {command.Id} already exists");

            var Product = _mapper.Map<Product>(command);

            var createdProduct = await _productRepository.CreateAsync(Product, cancellationToken);
            var result = _mapper.Map<CreateProductResult>(createdProduct);
            return result;

        }
    }
}
