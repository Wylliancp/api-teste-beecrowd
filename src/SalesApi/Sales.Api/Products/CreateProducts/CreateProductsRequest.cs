namespace Sales.Api.Products.CreateProducts;

public class CreateProductsRequest
{
    public CreateProductsRequest(string name, string category, string description, string imageFile, decimal price)
    {
        Name = name;
        Category = category;
        Description = description;
        ImageFile = imageFile;
        Price = price;
    }

    public string Name { get; set; } 
    public string Category { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public decimal Price { get; set; }
}