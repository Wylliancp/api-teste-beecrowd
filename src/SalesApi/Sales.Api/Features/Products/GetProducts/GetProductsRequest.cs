namespace Sales.Api.Features.Products.GetProducts;


public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);

