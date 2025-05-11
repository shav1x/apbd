using tut8.Infrastructure.Repositories;
using tut8.Infrastructure.Repositories.Abstractions;

namespace tut8.Services.Extensions;

public static class ServicesCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        
        return services;
    }
}
