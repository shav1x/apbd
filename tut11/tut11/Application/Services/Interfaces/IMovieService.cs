using tut11.Application.DTOs;

namespace tut11.Application.Services.Interfaces;

public interface IMovieService
{
    Task<bool> CreateMovie(MovieDto movieDto);
}