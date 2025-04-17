using MediatR;

namespace Sales.Application.Sales.DeleteSale;

public record DeleteSalesCommand : IRequest<DeleteSalesResponse>
{
    public Guid Id { get; }
    public DeleteSalesCommand(Guid id)
    {
        Id = id;
    }
}
