using AutoMapper;
using Sales.Application.Products.CreateProduct;
using Sales.Domain.Entities;

namespace Sales.Application.Sales.CreateSale;

public class CreateSalesProfile : Profile
{
    public CreateSalesProfile()
    {
        CreateMap<CreateSalesCommand, Sale>();
        CreateMap<CreateSaleItemCommand, SaleItem>();
        CreateMap<Sale, CreateSalesResult>();
        CreateMap<SaleItem, CreateSalesItemResult>();
    }
}
