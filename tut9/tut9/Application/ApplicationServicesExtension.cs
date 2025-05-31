using tut9.Application.Repositories;
using tut9.Application.Repositories.Interfaces;
using tut9.Application.Services;
using tut9.Application.Services.Interfaces;

namespace tut9.Application;

public static class ApplicationServicesExtension
{
    public static void RegisterApplicationServices(this IServiceCollection app)
    {
        app.AddScoped<ITripService, TripService>();
        app.AddScoped<ITripRepository, TripRepository>();
        app.AddScoped<IClientService, ClientService>();
        app.AddScoped<IClientRepository, ClientRepository>();
        app.AddDbContext<TripContext>();
    }
}
