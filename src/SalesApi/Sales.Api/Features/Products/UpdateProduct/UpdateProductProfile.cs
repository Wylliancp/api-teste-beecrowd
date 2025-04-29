using AutoMapper;
using Sales.Application.Products.UpdateProduct;

namespace Sales.Api.Features.Products.UpdateProduct;

public class UpdateProductProfile : Profile
{
    public UpdateProductProfile()
    {
        CreateMap<UpdateProductRequest, UpdateProductCommand>();
        CreateMap<UpdateProductResult, UpdatePorductsResponse>();
    }
}
