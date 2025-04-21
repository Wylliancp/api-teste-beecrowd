using Sales.Domain.Entities;

namespace Sales.Api.Features.Sales.CreateSales;

public class CreateSalesRequest
{

    public CreateSalesRequest(Guid customerId,
        List<CreateSaleItemRequest> items)
    {
        CustomerId = customerId;
        Items = items;
        
    }
    public Guid CustomerId { get; private set; }
    public List<CreateSaleItemRequest> Items { get; set; }//ajustar
}

public class CreateSaleItemRequest
{
    public CreateSaleItemRequest(Guid saleId, Guid productId, string productName, int quantity, decimal valueMonetaryTaxApplied, decimal unitPrice)
    {
        SaleId = saleId;
        ProductId = productId;
        ProductName = productName;
        UnitPrice = unitPrice;
        ValueMonetaryTaxApplied = valueMonetaryTaxApplied;
        Quantity = quantity;
    }

    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal ValueMonetaryTaxApplied { get; set; }
    public decimal UnitPrice { get; set; }
}