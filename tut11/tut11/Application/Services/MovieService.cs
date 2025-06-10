using Microsoft.IdentityModel.Tokens;
using tut11.Application.DTOs;
using tut11.Application.Exceptions;
using tut11.Application.Services.Interfaces;
using tut11.Core.Data;
using tut11.Core.Database;

namespace tut11.Application.Services;

public class MovieService(AppDbContext dbContext) : IMovieService
{
    public async Task<bool> CreateMovie(MovieDto movieDto)
    {
        foreach (var actorDto in movieDto.Actors!)
            if (!dbContext.Actors.Any(x => x.IdActor == actorDto.IdActor))
                throw new ActorDoesNotExistException(actorDto.IdActor);
        
        if (!dbContext.AgeRatings.Any(x => x.IdAgeRating == movieDto.AgeRating.IdAgeRating))
            throw new AgeRatingDoesNotExistException(movieDto.AgeRating.IdAgeRating);
        
        if (movieDto.ReleaseDate < DateTime.Now && movieDto.Actors.IsNullOrEmpty())
            throw new ActorsNotProvidedException();
                
        
        var newMovie = new Movie
        {
            Name = movieDto.Name,
            ReleaseDate = movieDto.ReleaseDate,
            AgeRatingId = movieDto.AgeRating.IdAgeRating
        };
        
        await dbContext.Movies.AddAsync(newMovie);
        await dbContext.SaveChangesAsync();

        if (!movieDto.Actors.IsNullOrEmpty())
        {
            foreach (var actorDto in movieDto.Actors)
            {
                var newActorMovie = new ActorMovie
                {
                    IdActor = actorDto.IdActor,
                    IdMovie = dbContext.Movies.First(x => x.Name == movieDto.Name).IdMovie,
                    CharacterName = actorDto.CharacterName
                };
                await dbContext.ActorMovies.AddAsync(newActorMovie);
                await dbContext.SaveChangesAsync();
            }
        }

        return true;
    }
}
