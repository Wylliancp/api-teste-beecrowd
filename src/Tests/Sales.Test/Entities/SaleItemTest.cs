using Sales.Domain.Entities;
using Sales.Domain.Enums;

namespace Sales.Test.Entities;

public class SaleItemTest
{
    static Guid ProductId = Guid.NewGuid();
    static Guid SaledId = Guid.NewGuid();
    const string? ProductName = "teste unitario";
    const int Quantity = 5;
    const decimal ValueMonetaryTaxApplied = 100;
    const decimal UnitPrice = 2000;
    const StatusSale Status = StatusSale.NOT_CANCELLED;
    
    [Fact]
    public void AddValueTotal()
    {
        var saleItem = new SaleItem(ProductId, SaledId, ProductName, Quantity, ValueMonetaryTaxApplied, UnitPrice);
        Assert.Equal(Quantity * UnitPrice - ValueMonetaryTaxApplied, saleItem.Total);
    }

    [Fact]
    public void CancelledSaleItemStatus()
    {
        SaleItem saleItem = new SaleItem(ProductId, SaledId, ProductName, Quantity, ValueMonetaryTaxApplied, UnitPrice);
        saleItem.CancelledSaleItemStatus();
        Assert.Equal(StatusSale.CANCELLED, saleItem.Status);
    }
}