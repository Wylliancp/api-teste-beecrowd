using FluentValidation;

namespace Sales.Api.Products.UpdateProducts;

public class UpdateProductsRequestValidator : AbstractValidator<UpdateProductsRequest>
{
    public UpdateProductsRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
    }
}