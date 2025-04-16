using AutoMapper;
using FluentValidation;
using MediatR;
using Sales.Domain.Entities;
using Sales.Domain.Repositories;

namespace Sales.Application.Products.CreateProduct;

public class CreateProductsHandler : IRequestHandler<CreateProductsCommand, CreateProductsResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateProductsHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<CreateProductsResult> Handle(CreateProductsCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateProductsCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = _mapper.Map<Product>(command);

        var createdUser = await _productRepository.CreateAsync(product, cancellationToken);
        var result = _mapper.Map<CreateProductsResult>(createdUser);
        return result;
    }
}
