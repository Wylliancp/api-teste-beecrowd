using AutoMapper;
using Sales.Application.Products.GetProduct;

namespace Sales.Api.Products.GetProduct;

public class GetProductProfile : Profile
{
    public GetProductProfile()
    {
        CreateMap<GetProductRequest, GetProductCommand>();
        CreateMap<GetProductResult, GetProductResponse>();
    }
}
