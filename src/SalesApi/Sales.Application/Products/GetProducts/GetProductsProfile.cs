using AutoMapper;
using Sales.Domain.Entities;

namespace Sales.Application.Products.GetProducts;

public class GetProductsProfile : Profile
{
    public GetProductsProfile()
    {
        CreateMap<Product, GetProductsResult>();
    }
}
