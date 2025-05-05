using tut7.Contracts.Requests;
using tut7.Entities;
using tut7.Exceptions;
using tut7.Repositories.Abstractions;
using tut7.Services.Abstractions;

namespace tut7.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<ICollection<ClientTrip>?> GetClientTripsAsync(int clientId, CancellationToken token = default)
        => await _clientRepository.GetClientTripsAsync(clientId, token);

    public async Task<int> CreateClientAsync(CreateClientRequest client, CancellationToken token = default)
    {
        var clientExists = await _clientRepository.ClientExistsByPeselAsync(client.Pesel, token);
        if (clientExists)
            throw new ClientWithPeselNumberExistsException(client.Pesel);

        var newClient = new Client
        {
            Telephone = client.Telephone,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email,
            Pesel = client.Pesel
        };
        
        var result = await _clientRepository.CreateClientAsync(newClient, token);
        return result.Id;
    }
}