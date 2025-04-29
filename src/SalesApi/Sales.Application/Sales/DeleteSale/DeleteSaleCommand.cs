using MediatR;

namespace Sales.Application.Sales.DeleteSale;

public record DeleteSaleCommand : IRequest<DeleteSaleResponse>
{
    public Guid Id { get; }
    public DeleteSaleCommand(Guid id)
    {
        Id = id;
    }
}
