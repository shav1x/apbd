using tut10.Application.Repositories;
using tut10.Application.Repositories.Interfaces;
using tut10.Application.Services;
using tut10.Application.Services.Interfaces;

namespace tut10.Application;

public static class ApplicationServicesExtension
{
    public static void RegisterApplicationServices(this IServiceCollection app)
    {
        app.AddScoped<IPrescriptionService, PrescriptionService>();
        app.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
        app.AddScoped<IPatientService, PatientService>();
        app.AddScoped<IPatientRepository, PatientRepository>();
    }
}
