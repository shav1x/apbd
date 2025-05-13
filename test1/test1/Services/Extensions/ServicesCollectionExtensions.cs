using test1.Services.Abstractions;

namespace test1.Services.Extensions;

public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITasksService, TasksService>();

        return services;
    }
}