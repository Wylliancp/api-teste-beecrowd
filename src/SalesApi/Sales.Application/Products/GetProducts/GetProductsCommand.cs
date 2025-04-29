using MediatR;

namespace Sales.Application.Products.GetProducts;

public record GetProductsCommand : IRequest<GetProductsResult>
{
    public GetProductsCommand(int? pageNumber, int? pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public int? PageNumber { get; init; } = 1;
    public int? PageSize { get; init; } = 10;

}
