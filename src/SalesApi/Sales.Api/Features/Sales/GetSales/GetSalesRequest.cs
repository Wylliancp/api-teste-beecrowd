namespace Sales.Api.Features.Sales.GetSales;


public record GetSalesRequest(int? PageNumber = 1, int? PageSize = 10);

