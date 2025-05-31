using tut9.Core.Models;

namespace tut9.Application.Repositories.Interfaces;

public interface ITripRepository
{
    Task<List<Trip>> GetAllTripsAsync();
    Task<PaginatedResult<Trip>> GetPaginatedTripsAsync(int pageNum = 1, int pageSize = 10);
    Task<List<ClientTrip>> GetAllClientTripsAsync();
    Task<List<CountryTrip>> GetAllCountryTripsAsync();
}
