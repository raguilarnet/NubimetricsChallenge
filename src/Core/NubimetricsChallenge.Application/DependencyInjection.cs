using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NubimetricsChallenge.Application.Interfaces.Services;
using NubimetricsChallenge.Application.Mappings;
using NubimetricsChallenge.Application.Services;

namespace NubimetricsChallenge.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IUsersServices, UserServices>();
        services.AddTransient<ICountriesService, CountriesService>();
        services.AddTransient<ISearchesService, SearchesService>();
        services.AddAutoMapper(c => c.AddProfile<AutoMapperConfigurationDto>(), AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
