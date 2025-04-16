using FluentValidation;

namespace Sales.Application.Products.DeleteProduct;

public class DeleteProductsValidator : AbstractValidator<DeleteProductsCommand>
{
    public DeleteProductsValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required");
    }
}
