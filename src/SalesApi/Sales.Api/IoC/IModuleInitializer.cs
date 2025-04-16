namespace Customers.Api.IoC;

public interface IModuleInitializer
{
    void Initialize(WebApplicationBuilder builder);
}
