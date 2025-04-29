using FluentValidation;

namespace Sales.Api.Features.Products.GetProducts;

public class GetProductsRequestValidator : AbstractValidator<GetProductsRequest>
{
    public GetProductsRequestValidator()
    {
    }
}
