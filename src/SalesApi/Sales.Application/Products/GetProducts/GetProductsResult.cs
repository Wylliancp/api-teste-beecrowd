using Sales.Domain.Entities;

namespace Sales.Application.Products.GetProducts;

public record GetProductsResult(IEnumerable<Product> Products);

