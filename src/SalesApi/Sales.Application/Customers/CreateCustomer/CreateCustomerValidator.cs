using FluentValidation;

namespace Sales.Application.Customers.CreateCustomer;

public class CreateUserCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(user => user.Name).NotEmpty().Length(3, 50);
    }
}