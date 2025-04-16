using AutoMapper;
using Sales.Application.Products.UpdateProduct;

namespace Sales.Api.Products.UpdateProducts;

public class UpdateProductsProfile : Profile
{
    public UpdateProductsProfile()
    {
        CreateMap<UpdateProductsRequest, UpdateProductsCommand>();
        CreateMap<UpdateProductsResult, UpdatePorductsResponse>();
    }
}
