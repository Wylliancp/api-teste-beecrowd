using AutoMapper;
using Sales.Application.Sales.DeleteSale;

namespace Sales.Api.Features.Sales.DeleteSales;

public class DeleteSalesProfile : Profile
{
    public DeleteSalesProfile()
    {
        CreateMap<Guid, DeleteSalesCommand>()
            .ConstructUsing(id => new DeleteSalesCommand(id));
    }
}
