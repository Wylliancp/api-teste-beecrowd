using AutoMapper;
using Sales.Domain.Entities;

namespace Sales.Application.Products.UpdateProduct;

public class UpdateProductsProfile : Profile
{
    public UpdateProductsProfile()
    {
        CreateMap<UpdateProductsCommand, Product>();
        CreateMap<Product, UpdateProductsResult>();
    }
}
