using tut7.Entities;

namespace tut7.Services.Abstractions;

public interface ITripService
{
    public Task<ICollection<Trip>> GetAllTripsAndCountriesAsync(CancellationToken cancellationToken = default);
    public ValueTask<bool> RegisterClientToTripAsync(int clientId, int tripId, CancellationToken cancellationToken = default);
}