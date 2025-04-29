using FluentValidation;

namespace Sales.Api.Features.Customers.CreateCustomer;

public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerRequestValidator()
    {
        RuleFor(user => user.Name).NotEmpty().Length(3, 50);
    }
}