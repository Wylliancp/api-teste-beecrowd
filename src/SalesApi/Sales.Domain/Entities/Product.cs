namespace Sales.Domain.Entities;

public class Product
{
    public Guid Id { get; }
    public string Name { get; private set; }
    public string Category { get; private set; }
    public string Description { get; private set; }
    public string ImageFile { get; private set; }
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }


    public Product(string name, string category, string description, string imageFile, decimal price)
    {
        Name = name;
        Category = category;
        Description = description;
        ImageFile = imageFile;
        Price = price;
        CreatedAt = DateTime.UtcNow;
    }
    public void UpdatePrice(decimal price)
    {
        Price = price;
        UpdatedAt = DateTime.UtcNow;
    }
    public void UpdateCategory(string category)
    {
        Category = category;
        UpdatedAt = DateTime.UtcNow;
    }
    public void UpdateDescription(string description)
    {
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }
}