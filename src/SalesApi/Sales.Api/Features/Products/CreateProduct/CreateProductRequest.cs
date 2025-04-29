namespace Sales.Api.Features.Products.CreateProduct;

public class CreateProductRequest
{
    public CreateProductRequest(string name, string category, string description, string imageFile, decimal price)
    {
        Name = name;
        Category = category;
        Description = description;
        ImageFile = imageFile;
        Price = price;
    }

    public string Name { get; private set; } 
    public string Category { get; private set; }
    public string Description { get; private set; }
    public string ImageFile { get; private set; }
    public decimal Price { get; private set; }
}