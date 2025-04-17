using AutoMapper;
using Sales.Domain.Entities;

namespace Sales.Application.Sales.GetSales;

public class GetSalesProfile : Profile
{
    public GetSalesProfile()
    {
        CreateMap<Sale, GetSalesResult>();
        CreateMap<SaleItem, GetSalesItemResult>();}
}
