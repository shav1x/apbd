using tut11.Application.Services;
using tut11.Application.Services.Interfaces;

namespace tut11.Application;

public static class ApplicationServicesExtension
{
    public static void RegisterApplicationServices(this IServiceCollection app)
    {
        app.AddScoped<IActorService, ActorService>();
        app.AddScoped<IMovieService, MovieService>();
    }
}
