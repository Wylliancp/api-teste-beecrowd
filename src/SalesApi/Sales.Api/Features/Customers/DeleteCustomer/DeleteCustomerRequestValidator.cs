using FluentValidation;

namespace Sales.Api.Features.Customers.DeleteCustomer;

public class DeleteCustomerRequestValidator : AbstractValidator<DeleteCustomerRequest>
{
    public DeleteCustomerRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Customer ID is required");
    }
}
