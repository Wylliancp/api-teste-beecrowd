using Sales.Domain.Entities;

namespace Sales.Test.Entities;

public sealed class ProductTest
{
    private const string Name = "teste unitario";
    private const string Category = "teste unitario"; 
    private const string Description = "teste unitario"; 
    private const string ImageFile = "teste unitario";
    private const decimal Price = 100;

    [Fact]
    public void ProductPrice100()
    {
        var product = new Product(Name, Category, Description, ImageFile, Price);
        Assert.Equal(100, product.Price);
    }
    
    [Fact]
    public void UpdateCategory()
    {
        var product = new Product(Name, Category, Description, ImageFile, Price);
        product.UpdateCategory("New Category");
        Assert.Equal("New Category", product.Category);
    }
    
    [Fact]
    public void UpdateDescription()
    {
        var product = new Product(Name, Category, Description, ImageFile, Price);
        product.UpdateDescription("New Description");
        Assert.Equal("New Description", product.Description);
    }
}