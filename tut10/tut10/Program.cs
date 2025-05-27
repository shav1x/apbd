using Microsoft.EntityFrameworkCore;
using tut10.Database;

namespace tut10;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        //
        var conString = builder.Configuration.GetConnectionString("Postgres");
        builder.Services.AddDbContext<PharmacyDbContext>(opt =>
        {
            opt.UseSqlServer(conString);
        });
        //

        var app = builder.Build();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        // Automatically updates the database once a new migration was created
        var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<PharmacyDbContext>();
        db.Database.Migrate();
        //
        
        app.MapControllers();

        app.Run();
    }
}
