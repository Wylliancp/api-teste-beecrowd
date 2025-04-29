using Sales.Domain.Entities;

namespace Sales.Api.Features.Products.GetProducts;

public record GetProductsResponse(IEnumerable<Product> Products);


