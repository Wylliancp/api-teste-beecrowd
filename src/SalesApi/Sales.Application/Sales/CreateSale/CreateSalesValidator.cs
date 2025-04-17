using FluentValidation;
using Sales.Application.Products.CreateProduct;

namespace Sales.Application.Sales.CreateSale;

public class CreateSalesCommandValidator : AbstractValidator<CreateSalesCommand>
{

    public CreateSalesCommandValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer is required");
        RuleFor(x => x.Items).NotEmpty().WithMessage("Items is required");
     }
}