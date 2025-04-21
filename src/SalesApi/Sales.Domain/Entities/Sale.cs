using Sales.Domain.Enums;

namespace Sales.Domain.Entities;

public class Sale
{
    public Sale()
    {
            
    }
    
    public Sale(Guid customerId, List<SaleItem> items)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;    
        BranchId = Guid.NewGuid();
        SaleNumber = new Random().Next(100000, 999999).ToString();
        SaleDate = DateTime.UtcNow;
        // Status = StatusSale.NOT_CANCELLED;
        Items = items;
    }
    public Guid Id { get; private set; }
    public string? SaleNumber { get; private set; }
    public DateTime SaleDate { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid BranchId { get; private set; }
    public List<SaleItem> Items { get; set; } = new();
    
    public decimal TotalPrice  => Items.Sum(x => x.UnitPrice * x.Quantity) 
                                  - Items.Sum(x => x.ValueMonetaryTaxApplied);
    
    // public StatusSale Status { get; private set; } = default!;


    // public void DeleteSaleStatus()
    // {
    //     Status = StatusSale.CANCELLED;
    // } 
}