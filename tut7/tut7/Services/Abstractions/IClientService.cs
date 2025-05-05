using tut7.Contracts.Requests;
using tut7.Entities;

namespace tut7.Services.Abstractions;

public interface IClientService
{
    public Task<ICollection<ClientTrip>?> GetClientTripsAsync(int clientId, CancellationToken cancellationToken = default);
    public Task<int> CreateClientAsync(CreateClientRequest client, CancellationToken cancellationToken = default);
}