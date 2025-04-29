namespace Sales.Api.Features.Sales.CreateSale;

public class CreateSaleResponse
{
    public CreateSaleResponse(Guid id, string saleNumber, DateTime saleDate, Guid customerId, Guid branchId, decimal totalPrice, List<CreateSaleItemResponse> items)
    {
        Id = id;
        SaleNumber = saleNumber;
        SaleDate = saleDate;
        CustomerId = customerId;
        BranchId = branchId;
        TotalPrice = totalPrice;
        Items = items;
    }

    public Guid Id { get; private set; }
    public string SaleNumber { get; private set; }
    public DateTime SaleDate { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid BranchId { get; private set; }
    public decimal TotalPrice { get; private set; }
    public List<CreateSaleItemResponse> Items { get; private set; } 
}

public class CreateSaleItemResponse
{
    public CreateSaleItemResponse(Guid id, Guid saleId, Guid productId, string? productName, int quantity, decimal valueMonetaryTaxApplied, decimal unitPrice, decimal total)
    {
        Id = id;
        SaleId = saleId;
        ProductId = productId;
        ProductName = productName;
        Quantity = quantity;
        ValueMonetaryTaxApplied = valueMonetaryTaxApplied;
        UnitPrice = unitPrice;
        Total = total;
    }

    public Guid Id { get; private set; }
    public Guid SaleId { get; private set; }
    public Guid ProductId { get; private set; }
    public string? ProductName { get; private set; }
    public int Quantity { get; private set; }
    public decimal ValueMonetaryTaxApplied { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal Total { get; private set; }
}