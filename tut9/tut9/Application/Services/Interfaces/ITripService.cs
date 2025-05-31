using tut9.Application.DTOs;
using tut9.Core.Models;

namespace tut9.Application.Services.Interfaces;

public interface ITripService
{
    Task<PaginatedResult<GetTripsDto>> GetPaginatedTripsAsync(int page = 1, int pageSize = 10);
    Task<List<GetTripsDto>> GetAllTripsAsync();
}
