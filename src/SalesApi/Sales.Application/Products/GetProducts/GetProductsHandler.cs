using AutoMapper;
using FluentValidation;
using MediatR;
using Sales.Domain.Repositories;

namespace Sales.Application.Products.GetProducts;

public class GetProductsHandler : IRequestHandler<GetProductsCommand, GetProductsResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductsHandler(
        IProductRepository productRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<GetProductsResult> Handle(GetProductsCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetProductsValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var products = await _productRepository.GetAllAsync(cancellationToken);
        if (products == null)
            throw new KeyNotFoundException($"Operation Error");

        return _mapper.Map<GetProductsResult>(products);
    }
}
