using Microsoft.EntityFrameworkCore;
using Sales.Infrastructure;

namespace Sales.Api.IoC;

public static class MigrationExtensions
{
    public static void MigrateDatabase(this WebApplication app)
    {
        //Not Functional - TODO Adjust to work with the new structure
        // using var scope = app.Services.CreateScope();
        // var dbContext = scope.ServiceProvider.GetRequiredService<DefaultContext>();
        // dbContext.Database.Migrate();
    }
}