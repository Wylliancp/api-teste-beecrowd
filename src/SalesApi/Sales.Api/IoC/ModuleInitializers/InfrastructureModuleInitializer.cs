using Customers.Api.IoC;
using Microsoft.EntityFrameworkCore;
using Sales.Domain.Repositories;
using Sales.Infrastructure;
using Sales.Infrastructure.Repositories;

namespace Sales.Api.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        
        builder.Services.AddDbContext<DefaultContext>(options =>
            options.UseNpgsql(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Sales.Infrastructure")
            )
        );
        // builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<ISaleRepository, SaleRepository>();
    }
}