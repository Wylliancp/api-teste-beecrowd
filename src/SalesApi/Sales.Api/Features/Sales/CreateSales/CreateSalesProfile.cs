using AutoMapper;
using Sales.Application.Sales.CreateSale;

namespace Sales.Api.Features.Sales.CreateSales;

public class CreateSalesProfile : Profile
{
    public CreateSalesProfile()
    {
        CreateMap<CreateSalesRequest, CreateSalesCommand>();
        CreateMap<CreateSaleItemRequest, CreateSaleItemCommand>();
        CreateMap<CreateSalesResult, CreateSalesResponse>();
        CreateMap<CreateSalesItemResult, CreateSalesItemResponse>();}
}
