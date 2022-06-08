using Microsoft.EntityFrameworkCore;
using NubimetricsChallenge.Infrastructure.Persistence.Contexts;

namespace NubimetricsChallenge.WebAPI.Helpers;

public static class DbMigrationHelpers
{
    public static async Task ApplyDataBaseMigrations(IHost appHost)
    {
        var scopeFactory = appHost.Services.GetService<IServiceScopeFactory>();
        using (var scope = scopeFactory.CreateScope())
        {
            //Apply Migrations
            var dataContext = scope.ServiceProvider.GetRequiredService<NubiChallengeContext>();
            dataContext.Database.Migrate();
        }
    }
    public static async Task ApplyDataBaseSeeder(IHost appHost)
    {
        var scopeFactory = appHost.Services.GetService<IServiceScopeFactory>();
        using (var scope = scopeFactory.CreateScope())
        {
            //Seed Data
            var service = scope.ServiceProvider.GetRequiredService<DataSeeder>();
            service.Seed();
        }
    }
}
