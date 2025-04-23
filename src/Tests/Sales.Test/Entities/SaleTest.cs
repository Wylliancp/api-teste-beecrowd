using Sales.Domain.Enums;
using Sales.Test.Entities;

namespace Sales.Domain.Entities;

public class SaleTest
{
    Guid CustomerId = Guid.NewGuid();
    List<SaleItem> Items { get; set; } = new();
    

    [Fact]
    public void CancelledSaleStatus()
    {
        var sale = new Sale(CustomerId, Items);
        sale.CancelledSaleStatus();
        Assert.Equal(StatusSale.CANCELLED, sale.Status);
    } 
    
    [Fact]
    public void SaleOk()
    {
        var sale = new Sale(CustomerId, Items);
        Assert.NotNull(sale);
    }
    
    [Fact]
    public void SaleTotalPrice()
    {
        var saleItem = new SaleItem(Guid.NewGuid(), Guid.NewGuid(), "teste unitario", 5, 100, 2000);
        var saleItems = new List<SaleItem> { saleItem };
        var sale = new Sale(CustomerId, saleItems);
        Assert.Equal(5 * 2000 - 100, sale.TotalPrice);
    }
}