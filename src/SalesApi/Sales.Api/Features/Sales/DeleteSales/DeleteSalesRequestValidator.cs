using FluentValidation;

namespace Sales.Api.Features.Sales.DeleteSales;

public class DeleteSalesRequestValidator : AbstractValidator<DeleteSalesRequest>
{
    public DeleteSalesRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}
