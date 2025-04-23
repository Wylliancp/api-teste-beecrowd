using Sales.Domain.Entities;

namespace Sales.Test.Entities;

public class ProductTest
{
    const string Name = "teste unitario";
    const string Category = "teste unitario"; 
    const string Description = "teste unitario"; 
    const string ImageFile = "teste unitario";
    const decimal Price = 100;

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