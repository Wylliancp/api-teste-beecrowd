using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Domain.Enums;
using Sales.Domain.Repositories;

namespace Sales.Infrastructure.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;
    
    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }
    
    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;    
    }

    public async Task<bool> CancelledAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if (sale == null)
            return false;
        
        sale.CancelledSaleStatus();
        
        var saleItems = await _context.SaleItems
            .Where(x => x.SaleId == id)
            .ToListAsync(cancellationToken);
        
        foreach (var item in saleItems)
        {
            item.CancelledSaleItemStatus();
        }
        
        _context.SaleItems.UpdateRange(saleItems);
        _context.Sales.Update(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;     
    }

    public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Sales.Include(x => x.Items).FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if (sale == null)
            return false;

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
    
    public async Task<List<Sale>?> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Sales.Include(x => x.Items)
            .Where(x => x.Status == StatusSale.NOT_CANCELLED)//TODO??
            .AsQueryable()
            .ToListAsync(cancellationToken);
    }

    public async Task<Sale?> UpdateSaleAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        _context.Sales.Update(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;    
    }
}