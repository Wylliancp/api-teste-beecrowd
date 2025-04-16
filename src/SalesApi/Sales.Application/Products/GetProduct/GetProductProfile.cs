using AutoMapper;
using Sales.Domain.Entities;

namespace Sales.Application.Products.GetProduct;

public class GetProductProfile : Profile
{
    public GetProductProfile()
    {
        CreateMap<Product, GetProductResult>();
    }
}
