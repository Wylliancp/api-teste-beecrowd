using MediatR;

namespace Sales.Application.Products.GetProducts;

public record GetProductsCommand : IRequest<GetProductsResult>
{
    public GetProductsCommand(int? pageNumber, int? pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public int? PageNumber { get; set; } = 1;
    public int? PageSize { get; set; } = 10;

}
