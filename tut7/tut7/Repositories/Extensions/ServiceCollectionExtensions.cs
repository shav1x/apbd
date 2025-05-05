using tut7.Repositories.Abstractions;

namespace tut7.Repositories.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ITripRepository, TripRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();

        return services;
    }
}