using FluentValidation;

namespace Sales.Api.Products.GetProducts;

public class GetProductsRequestValidator : AbstractValidator<GetProductsRequest>
{

    public GetProductsRequestValidator()
    {
    }
}
