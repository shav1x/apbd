using tut8.Services.Abstractions;

namespace tut8.Services.Extensions;

public static class ServicesCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductWarehouseService, ProductWarehouseService>();
        
        return services;
    }
}
