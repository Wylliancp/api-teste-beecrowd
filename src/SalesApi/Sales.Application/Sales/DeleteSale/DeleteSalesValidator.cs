using FluentValidation;
using Sales.Application.Products.DeleteProduct;

namespace Sales.Application.Sales.DeleteSale;

public class DeleteSalesValidator : AbstractValidator<DeleteSalesCommand>
{
    public DeleteSalesValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Sale ID is required");
    }
}
