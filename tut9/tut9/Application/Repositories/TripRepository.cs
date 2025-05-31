using Microsoft.EntityFrameworkCore;
using tut9.Application.Repositories.Interfaces;
using tut9.Core.Models;

namespace tut9.Application.Repositories;

public class TripRepository(TripContext tripContext) : ITripRepository
{
    
    public async Task<List<Trip>> GetAllTripsAsync()
    {
        return await tripContext.Trips
            .OrderByDescending(t => t.DateFrom)
            .ToListAsync();
    }

    public async Task<PaginatedResult<Trip>> GetPaginatedTripsAsync(int pageNum = 1, int pageSize = 10)
    {
        var allTrips = tripContext.Trips
            .OrderByDescending(t => t.DateFrom);
        
        var tripsCount = await allTrips.CountAsync();
        var totalPages = (int)Math.Ceiling((double)tripsCount / pageSize);
        
        var trips = await allTrips
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return new PaginatedResult<Trip>
        {
            PageNum = pageNum,
            PageSize = pageSize,
            AllPages = totalPages,
            Data = trips
        };
    }

    public async Task<List<ClientTrip>> GetAllClientTripsAsync()
    {
        return await tripContext.ClientTrips
            .Include(ct => ct.IdClientNavigation)
            .ToListAsync();
    }

    public async Task<List<CountryTrip>> GetAllCountryTripsAsync()
    {
        return await tripContext.CountryTrips
            .Include(ct => ct.IdCountryNavigation)
            .ToListAsync();
    }
}