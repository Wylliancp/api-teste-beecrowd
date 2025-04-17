using System.Text.Json.Serialization;
using Sales.Domain.Enums;

namespace Sales.Domain.Entities;

public class SaleItem
{
    public SaleItem()
    {
    }
    public SaleItem(Guid saleId, Guid productId, string? productName, int quantity, decimal valueMonetaryTaxApplied, decimal unitPrice)
    {
        SaleId = saleId;
        ProductId = productId;
        ProductName = productName;
        Quantity = quantity;
        ValueMonetaryTaxApplied = valueMonetaryTaxApplied;
        UnitPrice = unitPrice;
        AddValueTotal();
        Status = StatusSale.NOT_CANCELLED;
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }
    
    public Guid SaleId { get; set; } // Chave estrangeira
    
    [JsonIgnore] // Ignorar a referência cíclica
    public Sale? Sale { get; set; } // Propriedade de navegação
    public Guid ProductId { get; private set; }
    public string? ProductName { get; private set; }
    public int Quantity { get; private set; } = default!;
    public decimal ValueMonetaryTaxApplied { get; set; }
    public decimal UnitPrice { get; private set; }
    public decimal Total { get; private set; }
    public StatusSale Status { get; private set; } = default!;
    
    
    private void AddValueTotal()
    {
        Total = (UnitPrice * Quantity) - ValueMonetaryTaxApplied;
    }

    public void DeleteSaleItemStatus()
    {
        Status = StatusSale.CANCELLED;
    }
}