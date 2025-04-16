using AutoMapper;
using Sales.Application.Products.DeleteProduct;

namespace Sales.Api.Products.DeleteProducts;

public class DeleteProductsProfile : Profile
{
    public DeleteProductsProfile()
    {
        CreateMap<Guid, DeleteProductsCommand>()
            .ConstructUsing(id => new DeleteProductsCommand(id));
    }
}
