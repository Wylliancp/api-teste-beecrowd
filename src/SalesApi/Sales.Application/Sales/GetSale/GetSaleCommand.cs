using MediatR;

namespace Sales.Application.Sales.GetSale;

public class GetSaleCommand : IRequest<GetSaleResult>
{
    public GetSaleCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; init; }

}
