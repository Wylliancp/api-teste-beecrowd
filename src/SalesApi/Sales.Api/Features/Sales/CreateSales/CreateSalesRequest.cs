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
    public CreateSaleItemRequest(Guid productId, decimal unitPrice, int quantity, string productName)
    {
        ProductId = productId;
        UnitPrice = unitPrice;
        Quantity = quantity;
        ProductName = productName;
    }

    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}