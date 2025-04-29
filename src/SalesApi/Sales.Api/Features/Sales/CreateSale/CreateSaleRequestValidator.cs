using FluentValidation;

namespace Sales.Api.Features.Sales.CreateSale;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Sales is required");
        RuleFor(x => x.Items).NotEmpty().WithMessage("Items is required");
    }
}