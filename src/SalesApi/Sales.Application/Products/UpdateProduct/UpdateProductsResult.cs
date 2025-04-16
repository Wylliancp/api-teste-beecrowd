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
    public string Name { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public decimal Price { get; set; }

}
