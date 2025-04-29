using MediatR;

namespace Sales.Application.Products.DeleteProduct;

public record DeleteProductCommand : IRequest<DeleteProductResponse>
{
    public Guid Id { get; }
    public DeleteProductCommand(Guid id)
    {
        Id = id;
    }
}
