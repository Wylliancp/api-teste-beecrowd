using AutoMapper;
using Sales.Domain.Entities;

namespace Sales.Application.Products.CreateProduct;

public class CreateProductsProfile : Profile
{
    public CreateProductsProfile()
    {
        CreateMap<CreateProductsCommand, Product>();
        CreateMap<Product, CreateProductsResult>();
    }
}
