
namespace Sales.Application.Products.GetProduct;

public class GetProductResult{
    public string Name { get; init; } = default!;
    public string Category { get; init; } = default!;
    public string Description { get; init; } = default!;
    public string ImageFile { get; init; } = default!;
    public decimal Price { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}

