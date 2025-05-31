using tut9.Application.DTOs;
using tut9.Application.Mappers;
using tut9.Application.Repositories.Interfaces;
using tut9.Application.Services.Interfaces;
using tut9.Core.Models;

namespace tut9.Application.Services;

public class TripService(ITripRepository tripRepository) : ITripService
{
    
    public async Task<PaginatedResult<GetTripsDto>> GetPaginatedTripsAsync(int page = 1, int pageSize = 10)
    {
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 10;
        
        var result = await tripRepository.GetPaginatedTripsAsync(page, pageSize);
        
        var allCountryTrips = await tripRepository.GetAllCountryTripsAsync();
        var allClientTrips = await tripRepository.GetAllClientTripsAsync();
        
        var mappedTrips = new PaginatedResult<GetTripsDto>
        {
            Data = result.Data.Select(trip => trip.MapToGetTripDto(allCountryTrips, allClientTrips)).ToList(),
            PageNum = result.PageNum,
            PageSize = result.PageSize,
            AllPages = result.AllPages
        };

        return mappedTrips;
    }

    public async Task<List<GetTripsDto>> GetAllTripsAsync()
    {
        var allCountryTrips = await tripRepository.GetAllCountryTripsAsync();
        var allClientTrips = await tripRepository.GetAllClientTripsAsync();
        
        var trips = await tripRepository.GetAllTripsAsync();
        var mappedTrips = trips.Select(trip => trip.MapToGetTripDto(allCountryTrips, allClientTrips)).ToList();
        return mappedTrips;
    }
    
}
