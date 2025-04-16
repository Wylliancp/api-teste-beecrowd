using FluentValidation;
using MediatR;
using Sales.Domain.Repositories;

namespace Sales.Application.Products.DeleteProduct;

public class DeleteProductsHandler : IRequestHandler<DeleteProductsCommand, DeleteProductsResponse>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductsHandler(
        IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<DeleteProductsResponse> Handle(DeleteProductsCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteProductsValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _productRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"User with ID {request.Id} not found");

        return new DeleteProductsResponse { Success = true };
    }
}
