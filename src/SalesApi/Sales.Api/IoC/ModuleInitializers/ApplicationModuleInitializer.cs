using MassTransit;
using Sales.Application;
using Sales.Application.Events;
using Sales.Domain.Events;

namespace Sales.Api.IoC.ModuleInitializers;

public class ApplicationModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(ApplicationLayer).Assembly);

        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(
                typeof(ApplicationLayer).Assembly,
                typeof(Program).Assembly
            );
        });
        builder.Services.AddScoped<ISaleEventHandler, SaleEventHandler>();

        
        // Configuração do MassTransit com RabbitMQ
        var rabbitMqHost = builder.Configuration.GetSection("RabbitMQ:Host").Value;
        var rabbitMqUsername = builder.Configuration.GetSection("RabbitMQ:Username").Value;
        var rabbitMqPassword = builder.Configuration.GetSection("RabbitMQ:Password").Value;
        var rabbitMqPort = builder.Configuration.GetSection("RabbitMQ:Port").Value;

        builder.Services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                if (rabbitMqPort != null)
                    cfg.Host(rabbitMqHost, ushort.Parse(rabbitMqPort), "/", h =>
                    {
                        if (rabbitMqUsername != null) h.Username(rabbitMqUsername);
                        if (rabbitMqPassword != null) h.Password(rabbitMqPassword);
                    });
            });
        });
    }
}