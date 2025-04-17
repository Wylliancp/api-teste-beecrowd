

using Sales.Domain.Entities;

namespace Sales.Application.Sales.GetSales;

public record GetSalesResult(IEnumerable<Sale> Sales);
public record GetSalesItemResult(IEnumerable<SaleItem> Sales);
