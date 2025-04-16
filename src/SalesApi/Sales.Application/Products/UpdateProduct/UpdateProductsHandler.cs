using AutoMapper;
using FluentValidation;
using MediatR;
using Sales.Domain.Repositories;

namespace Sales.Application.Products.UpdateProduct;

public class UpdateProductsHandler : IRequestHandler<UpdateProductsCommand, UpdateProductsResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public UpdateProductsHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<UpdateProductsResult> Handle(UpdateProductsCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductsCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = await _productRepository.GetByIdAsync(command.Id, cancellationToken);
        if (product is null)
            throw new InvalidOperationException($"Not Product already exists");

        product.UpdateCategory(command.Category); //Update
        product.UpdateDescription(command.Description);
        product.UpdatePrice(command.Price);

        var updateProduct = await _productRepository.UpdateProductAsync(product, cancellationToken);
        var result = _mapper.Map<UpdateProductsResult>(updateProduct);
        return result;
    }
}
