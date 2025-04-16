using MediatR;

namespace Sales.Application.Products.DeleteProduct;

public record DeleteProductsCommand : IRequest<DeleteProductsResponse>
{
    public Guid Id { get; }
    public DeleteProductsCommand(Guid id)
    {
        Id = id;
    }
}
