using MediatR;
using Sales.Application.Validation;

namespace Sales.Application.Customers.CreateCustomer;

public class CreateCustomerCommand : IRequest<CreateCustomerResult>
{
    public string Name { get; set; } = string.Empty;
       

    public ValidationResponseDetail Validate()
    {
        var validator = new CreateUserCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResponseDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}