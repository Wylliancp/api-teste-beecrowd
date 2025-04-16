using MediatR;

namespace Sales.Application.Products.GetProduct;

public class GetProductCommand : IRequest<GetProductResult>
{
    public GetProductCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }

}
