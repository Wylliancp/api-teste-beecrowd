using AutoMapper;
using Sales.Domain.Entities;

namespace Sales.Application.Customers.GetCustomer;

public class GetCustomerProfile : Profile
{
    public GetCustomerProfile()
    {
        CreateMap<Customer, GetCustomerResult>();
    }
}
