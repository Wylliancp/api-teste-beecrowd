using FluentValidation;

namespace Sales.Api.Products.DeleteProducts;

public class DeleteProductsRequestValidator : AbstractValidator<DeleteProductsRequest>
{
    public DeleteProductsRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
