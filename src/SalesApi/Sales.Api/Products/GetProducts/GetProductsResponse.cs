using Sales.Domain.Entities;

namespace Sales.Api.Products.GetProducts;

public record GetProductsResponse(IEnumerable<Product> Products);


