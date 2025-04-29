namespace Sales.Api.Features.Products.GetProduct;

public class GetProductResponse()
{
    public string Name { get; private set; } = default!;
    public string Category { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public string ImageFile { get; private set; } = default!;
    public decimal Price { get; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; }
}


