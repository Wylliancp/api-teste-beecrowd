using FluentValidation;

namespace Sales.Api.Products.GetProduct;

public class GetProductRequestValidator : AbstractValidator<GetProductRequest>
{

    public GetProductRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
    }
}
