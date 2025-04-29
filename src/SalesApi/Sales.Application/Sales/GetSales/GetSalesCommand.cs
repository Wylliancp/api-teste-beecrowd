using MediatR;

namespace Sales.Application.Sales.GetSales;

public record GetSalesCommand : IRequest<GetSalesResult>
{
    public GetSalesCommand(int? pageNumber, int? pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public int? PageNumber { get; init; } = 1;
    public int? PageSize { get; init; } = 10;

}
