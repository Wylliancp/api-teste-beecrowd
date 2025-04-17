using AutoMapper;
using Sales.Application.Products.CreateProduct;

namespace Sales.Api.Products.CreateProducts;

public class CreateProductsProfile : Profile
{
    public CreateProductsProfile()
    {
        CreateMap<CreateProductsRequest, CreateProductsCommand>();
        CreateMap<CreateProductsResult, CreateProductsResponse>();
    }
}
