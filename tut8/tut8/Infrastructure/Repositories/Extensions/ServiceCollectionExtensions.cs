using tut8.Infrastructure.Repositories.Abstractions;

namespace tut8.Infrastructure.Repositories.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductWarehouseRepository, ProductWarehouseRepository>();
        services.AddScoped<IWarehouseRepository, WarehouseRepository>();

        return services;
    }
}
