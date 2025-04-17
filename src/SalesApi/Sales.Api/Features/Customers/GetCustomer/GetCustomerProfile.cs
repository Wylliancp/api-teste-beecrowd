using AutoMapper;
using Sales.Application.Customers.GetCustomer;

namespace Sales.Api.Customers.GetCustomer;

public class GetCustomerProfile : Profile
{
    public GetCustomerProfile()
    {
        CreateMap<Guid, GetCustomerCommand>()
            .ConstructUsing(id => new GetCustomerCommand(id));
        CreateMap<GetCustomerResult, GetCustomerResponse>();
    }
}
