namespace Sales.Application.Products.UpdateProduct;

public class UpdateProductResult
{
    public UpdateProductResult()
    {
    }

    public UpdateProductResult(Guid id, string name, string category, string description, string imageFile, decimal price)
    {
        Id = id;
        Name = name;
        Category = category;
        Description = description;
        ImageFile = imageFile;
        Price = price;
    }
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string Category { get; init; } = default!;
    public string Description { get; init; } = default!;
    public string ImageFile { get; init; } = default!;
    public decimal Price { get; init; }

}
