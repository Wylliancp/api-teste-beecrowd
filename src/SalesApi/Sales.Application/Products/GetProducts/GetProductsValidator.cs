using FluentValidation;

namespace Sales.Application.Products.GetProducts;

public class GetProductsValidator : AbstractValidator<GetProductsCommand>
{
    public GetProductsValidator()
    {
    }
}
