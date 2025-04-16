using MediatR;

namespace Sales.Application.Customers.GetCustomer;

public record GetCustomerCommand : IRequest<GetCustomerResult>
{
    public Guid Id { get; }

    public GetCustomerCommand(Guid id)
    {
        Id = id;
    }
}
