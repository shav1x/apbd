using test1.Infrastructure.Repositories.Abstractions;

namespace test1.Infrastructure.Repositories.Extensions;

public static class RepositoriesCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ITasksRepository, TasksRepository>();

        return services;
    }
}