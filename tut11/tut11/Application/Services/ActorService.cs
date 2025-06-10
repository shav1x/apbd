using Microsoft.EntityFrameworkCore;
using tut11.Application.DTOs;
using tut11.Application.Exceptions;
using tut11.Application.Services.Interfaces;
using tut11.Core.Data;
using tut11.Core.Database;

namespace tut11.Application.Services;

public class ActorService(AppDbContext dbContext) : IActorService
{
    public async Task<IEnumerable<Actor>> GetAllActors(string? name, string? surname)
    {
        var query = dbContext.Actors
            .Include(x => x.ActorMovies)
            .ThenInclude(x => x.Movie)
            .ThenInclude(x => x.AgeRating)
            .AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(x => x.Name.Contains(name));
        
        if (!string.IsNullOrWhiteSpace(surname))
            query = query.Where(x => x.Surname.Contains(surname));
        
        query = query.OrderBy(x => x.Name);
        
        return await query.ToListAsync();
    }
    
}
