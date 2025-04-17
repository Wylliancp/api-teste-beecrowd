namespace Sales.Application.Products.UpdateProduct;

public class UpdateProductsResult
{
    public UpdateProductsResult()
    {
    }

    public UpdateProductsResult(Guid id, string name, string category, string description, string imageFile, decimal price)
    {
        Id = id;
        Name = name;
        Category = category;
        Description = description;
        ImageFile = imageFile;
        Price = price;
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Category { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ImageFile { get; set; } = default!;
    public decimal Price { get; set; }

}
