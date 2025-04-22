using Sales.Domain.Entities;

namespace Sales.Domain.Repositories;

public interface ISaleRepository
{
    Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> CancelledAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Sale>?> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Sale?> UpdateSaleAsync(Sale sale, CancellationToken cancellationToken = default);
}
