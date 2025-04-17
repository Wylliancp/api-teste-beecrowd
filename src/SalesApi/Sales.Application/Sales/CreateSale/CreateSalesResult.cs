using Sales.Domain.Enums;

namespace Sales.Application.Sales.CreateSale;
public class CreateSalesResult
{
       public Guid Id { get; set; }
       public string SaleNumber { get; private set; }
       public DateTime SaleDate { get; private set; }
       public Guid CustomerId { get; private set; }
       public Guid BranchId { get; private set; }
       public decimal TotalPrice { get; set; }
       public List<CreateSalesItemResult> Items { get; set; } 
}

public class CreateSalesItemResult
{
       public CreateSalesItemResult(Guid id, Guid saleId, Guid productId, string? productName, int quantity, decimal valueMonetaryTaxApplied, decimal unitPrice, decimal total)
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
       public Guid SaleId { get; set; }
       public Guid ProductId { get; private set; }
       public string? ProductName { get; private set; }
       public int Quantity { get; private set; } = default!;
       public decimal ValueMonetaryTaxApplied { get; set; }
       public decimal UnitPrice { get; private set; }
       public decimal Total { get; private set; }
}
