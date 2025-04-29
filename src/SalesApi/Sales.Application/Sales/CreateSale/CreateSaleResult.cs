using Sales.Domain.Enums;

namespace Sales.Application.Sales.CreateSale;
public class CreateSaleResult
{
       public CreateSaleResult(Guid id, string? saleNumber, DateTime saleDate, Guid customerId, Guid branchId, decimal totalPrice, List<CreateSaleItemResult>? items)
       {
              Id = id;
              SaleNumber = saleNumber;
              SaleDate = saleDate;
              CustomerId = customerId;
              BranchId = branchId;
              TotalPrice = totalPrice;
              Items = items;
       }

       public Guid Id { get; }
       public string? SaleNumber { get; }
       public DateTime SaleDate { get; }
       public Guid CustomerId { get; }
       public Guid BranchId { get; }
       public decimal TotalPrice { get; init; }
       public List<CreateSaleItemResult>? Items { get; } 
}

public class CreateSaleItemResult
{
       public CreateSaleItemResult(Guid id, Guid saleId, Guid productId, string? productName, int quantity, decimal valueMonetaryTaxApplied, decimal unitPrice, decimal total)
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
