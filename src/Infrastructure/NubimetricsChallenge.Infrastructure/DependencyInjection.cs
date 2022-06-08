using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NubimetricsChallenge.Application.Interfaces;
using NubimetricsChallenge.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using NubimetricsChallenge.Infrastructure.Persistence;
using NubimetricsChallenge.Application.Interfaces.Repositories;
using NubimetricsChallenge.Infrastructure.Persistence.Repositories;

namespace NubimetricsChallenge.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("NubiChallenge");


        services.AddDbContext<NubiChallengeContext>(options =>
            options.UseSqlServer(connectionString,
            b => b.MigrationsAssembly(typeof(NubiChallengeContext).Assembly.FullName)), ServiceLifetime.Transient);

        services.AddScoped<INubiChallengeContext>(provider => provider.GetService<NubiChallengeContext>());

        services.AddTransient<IUserRepository, UserRepository>();

        services.AddScoped<IUnitOfWork>(option => new UnitOfWork(new NubiChallengeContext(connectionString)));

        services.AddTransient<DataSeeder>();

        return services;
    }
}
