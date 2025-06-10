using tut11.Application.DTOs;
using tut11.Core.Data;

namespace tut11.Application.Services.Interfaces;

public interface IActorService
{
    Task<IEnumerable<Actor>> GetAllActors(string? name, string? surname);
}
