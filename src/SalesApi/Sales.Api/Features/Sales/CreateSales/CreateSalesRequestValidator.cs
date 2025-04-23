using FluentValidation;
using Sales.Api.Products.CreateProducts;

namespace Sales.Api.Features.Sales.CreateSales;

public class CreateSalesRequestValidator : AbstractValidator<CreateSalesRequest>
{
    public CreateSalesRequestValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Sales is required");
        RuleFor(x => x.Items).NotEmpty().WithMessage("Items is required");
    }
}