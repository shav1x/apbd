using tut7.Services.Abstractions;

namespace tut7.Services.Extensions;

public static class ServicesCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITripService, TripService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}