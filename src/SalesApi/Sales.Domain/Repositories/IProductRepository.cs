using Sales.Domain.Entities;

namespace Sales.Domain.Repositories;

public interface IProductRepository
{
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Product>?> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Product?> UpdateProductAsync(Product product, CancellationToken cancellationToken = default);
}
