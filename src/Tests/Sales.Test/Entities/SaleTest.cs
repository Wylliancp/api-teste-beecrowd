using Sales.Domain.Entities;
using Sales.Domain.Enums;

namespace Sales.Test.Entities;

public sealed class SaleTest
{
    private readonly Guid _customerId = Guid.NewGuid();
    private List<SaleItem> Items { get; set; } = new();
    
    [Fact]
    public void CancelledSaleStatus()
    {
        var sale = new Sale(_customerId, Items);
        sale.CancelledSaleStatus();
        Assert.Equal(StatusSale.CANCELLED, sale.Status);
    } 
    
    [Fact]
    public void SaleOk()
    {
        var sale = new Sale(_customerId, Items);
        Assert.NotNull(sale);
    }
    
    [Fact]
    public void SaleTotalPrice()
    {
        var saleItem = new SaleItem(Guid.NewGuid(), Guid.NewGuid(), "teste unitario", 15, 100, 2000);
        var saleItems = new List<SaleItem> { saleItem };
        var sale = new Sale(_customerId, saleItems);
        Assert.Equal((15 * 2000) - 400, sale.TotalPrice);
    }
    
    [Fact]
    public void ItNotPossibleToSellAbove20IdenticalItems()
    {
        var saleItem = new SaleItem(Guid.NewGuid(), Guid.NewGuid(), "teste unitario", 20, 100, 2000);
        var saleItems = new List<SaleItem> { saleItem };
        var sale = new Sale(_customerId, saleItems);
        Assert.True(sale.ItNotPossibleToSellAbove20IdenticalItems());
    }
    
    [Fact]
    public void PurchasesBelow4ItemsHaveFreeTax()
    {
        var saleItem = new SaleItem(Guid.NewGuid(), Guid.NewGuid(), "teste unitario", 3, 100, 2000);
        var saleItems = new List<SaleItem> { saleItem };
        var sale = new Sale(_customerId, saleItems);
        Assert.Equal(0, sale.Items.Sum(x => x.ValueMonetaryTaxApplied));
    }
    
    [Fact]
    public void PurchasesBetween10And20IdenticalItemsHaveSpecialiva20Percent()
    {
        var saleItem = new SaleItem(Guid.NewGuid(), Guid.NewGuid(), "teste unitario", 15, 100, 2000);
        var saleItems = new List<SaleItem> { saleItem };
        var sale = new Sale(_customerId, saleItems);
        Assert.Equal(400, sale.Items.Sum(x => x.ValueMonetaryTaxApplied));
    }
    
    [Fact]
    public void PurchasesAbove4IdenticalItemsHaveIvatax10Percent()
    {
        var saleItem = new SaleItem(Guid.NewGuid(), Guid.NewGuid(), "teste unitario", 5, 100, 2000);
        var saleItems = new List<SaleItem> { saleItem };
        var sale = new Sale(_customerId, saleItems);
        Assert.Equal(200, sale.Items.Sum(x => x.ValueMonetaryTaxApplied));
    }
}