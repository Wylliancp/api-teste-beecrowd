
namespace Sales.Application.Sales.GetSale;

public class GetSaleResult{
    
    public GetSaleResult(Guid id, string saleNumber, DateTime saleDate, Guid customerId, Guid branchId, decimal totalPrice, List<GetSaleItemResult> items)
    {
        Id = id;
        SaleNumber = saleNumber;
        SaleDate = saleDate;
        CustomerId = customerId;
        BranchId = branchId;
        TotalPrice = totalPrice;
        Items = items;
    }
    public Guid Id { get; init; }
    public string SaleNumber { get; private set; }
    public DateTime SaleDate { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid BranchId { get; private set; }
    public decimal TotalPrice { get; init; }
    public List<GetSaleItemResult> Items { get; init; }
}

public class GetSaleItemResult
{
    public GetSaleItemResult(Guid productId, decimal unitPrice, int quantity, Guid id, decimal valueMonetaryTaxApplied, decimal total, Guid saleId)
    {
        ProductId = productId;
        UnitPrice = unitPrice;
        Quantity = quantity;
        Id = id;
        ValueMonetaryTaxApplied = valueMonetaryTaxApplied;
        Total = total;
        SaleId = saleId;
    }

    public Guid Id { get; init; }
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }
    public decimal ValueMonetaryTaxApplied { get; init; }
    public decimal Total { get; init; }
    public Guid SaleId { get; init; }
}

