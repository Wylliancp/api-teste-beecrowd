using Sales.Api.Features.Sales.GetSale;
using Sales.Domain.Entities;

namespace Sales.Api.Features.Sales.GetSales;

public record GetSalesResponse(IEnumerable<Sale> Sales);


