using Sales.Domain.Enums;

namespace Sales.Api.Features.Sales.GetSale;

public class GetSaleResponse
{
    public GetSaleResponse(Guid id, string saleNumber, DateTime saleDate, Guid customerId, Guid branchId, decimal totalPrice, List<GetSaleItemResponse> items)
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
    // public StatusSale Status { get; set; }//TODO VERIFICAR
    public List<GetSaleItemResponse> Items { get; private set; }
}

public class GetSaleItemResponse
{
    public GetSaleItemResponse(Guid productId, decimal unitPrice, int quantity, Guid id, decimal valueMonetaryTaxApplied, decimal total, Guid saleId)
    {
        ProductId = productId;
        UnitPrice = unitPrice;
        Quantity = quantity;
        Id = id;
        ValueMonetaryTaxApplied = valueMonetaryTaxApplied;
        Total = total;
        SaleId = saleId;
    }

    public Guid Id { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal ValueMonetaryTaxApplied { get; private set; }
    public decimal Total { get; private set; }
    public Guid SaleId { get; private set; }
    // public StatusSale Status { get; set; } = default!;TODO VERIFICAR
}



