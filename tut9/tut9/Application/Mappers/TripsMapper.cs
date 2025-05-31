using tut9.Application.DTOs;
using tut9.Core.Models;

namespace tut9.Application.Mappers;

public static class TripsMapper
{
    public static GetTripsDto MapToGetTripDto(this Trip trip, List<CountryTrip> countryTrips, List<ClientTrip> clientTrips)
    {
        return new GetTripsDto
        {
            Name = trip.Name,
            Description = trip.Description,
            DateFrom = trip.DateFrom,
            DateTo = trip.DateTo,
            MaxPeople = trip.MaxPeople,
            Countries = countryTrips
                .Where(ct => ct.IdTrip == trip.IdTrip)
                .Select(ct => ct.IdCountryNavigation.MapToCountryDto())
                .ToList(),
            Client = clientTrips
                .Where(ct => ct.IdTrip == trip.IdTrip)
                .Select(clientTrip => clientTrip.IdClientNavigation.MapToCountryDto())
                .ToList()
        };

    }
}
