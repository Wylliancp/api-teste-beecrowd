using MediatR;

namespace Sales.Application.Customers.DeleteCustomer;

public record DeleteCustomerCommand : IRequest<DeleteCustomerResponse>
{
    public Guid Id { get; }
    
    public DeleteCustomerCommand(Guid id)
    {
        Id = id;
    }
}
