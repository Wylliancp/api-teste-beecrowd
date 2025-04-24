using Sales.Domain.Entities;
using Sales.Domain.Enums;

namespace Sales.Test.Entities;

public sealed class SaleItemTest
{
    private static readonly Guid ProductId = Guid.NewGuid();
    private static readonly Guid SaledId = Guid.NewGuid();
    private const string? ProductName = "teste unitario";
    private const int Quantity = 5;
    private const decimal ValueMonetaryTaxApplied = 100;
    private const decimal UnitPrice = 2000;
    private const StatusSale Status = StatusSale.NOT_CANCELLED;
    
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