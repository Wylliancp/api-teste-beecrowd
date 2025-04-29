using AutoMapper;
using Sales.Application.Products.GetProducts;

namespace Sales.Api.Features.Products.GetProducts;

public class GetProductsProfile : Profile
{
    public GetProductsProfile()
    {
        CreateMap<GetProductsRequest, GetProductsCommand>();
        CreateMap<GetProductsResult, GetProductsResponse>();
    }
}
