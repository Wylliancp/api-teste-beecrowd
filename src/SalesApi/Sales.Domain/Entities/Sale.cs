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
        Status = StatusSale.NOT_CANCELLED;
        Items = items;
        PurchasesAbove4IdenticalItemsHaveIvatax();
        PurchasesBetween10And20IdenticalItemsHaveSpecialiva();
        PurchasesBelow4ItemsHaveFreeTax();
    }
    public Guid Id { get; private set; }
    public string? SaleNumber { get; private set; }
    public DateTime SaleDate { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid BranchId { get; private set; }
    public List<SaleItem> Items { get; set; } = new();
    
    public decimal TotalPrice  => Items.Sum(x => x.UnitPrice * x.Quantity) 
                                  - Items.Sum(x => x.ValueMonetaryTaxApplied);
    
    public StatusSale Status { get; private set; } = default!;


    public void CancelledSaleStatus()
    {
        Status = StatusSale.CANCELLED;
    }

    private void PurchasesAbove4IdenticalItemsHaveIvatax()
    {
        if (Items.Count == 0)
            return;
        
        var itemsInternal = Items
            .Where(x => x.Quantity > 4)
            .Select(x => x);
        
        var itemsGeneral = Items
            .GroupBy(x => x.ProductId)
            .Where(x => x.Count() > 4)
            .SelectMany(x => x);
        
        foreach (var item in itemsGeneral)
        {
            item.ValueMonetaryTaxApplied = item.UnitPrice * 0.1m;
        }

        foreach (var item in itemsInternal)
        {
            item.ValueMonetaryTaxApplied = item.UnitPrice * 0.1m;
        }
    }

    private void PurchasesBetween10And20IdenticalItemsHaveSpecialiva()
    {
        if (Items.Count == 0)
            return;
        
        var items = Items
            .Where(x => x.Quantity >= 10 && x.Quantity <= 20)
            .Select(x => x);

        foreach (var item in items)
        {
            item.ValueMonetaryTaxApplied = item.UnitPrice * 0.2m;
        }
    }

    private void PurchasesBelow4ItemsHaveFreeTax()
    {
        if (Items.Count == 0)
            return;
        
        var itemsInternal = Items
            .Where(x => x.Quantity < 4)
            .Select(x => x);

        foreach (var item in itemsInternal)
        {
            item.ValueMonetaryTaxApplied = 0;
        }
    }

    public bool ItNotPossibleToSellAbove20IdenticalItems()
    {
        if (Items.Count == 0)
            return false;
        
        var items = Items
            .Where(x => x.Quantity >= 20)
            .Select(x => x);

        if (items.Any())
        {
            return true;
        }
        return false;
    }
}