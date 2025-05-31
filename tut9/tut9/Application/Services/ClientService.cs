using tut9.Application.DTOs;
using tut9.Application.Exceptions;
using tut9.Application.Repositories.Interfaces;
using tut9.Application.Services.Interfaces;

namespace tut9.Application.Services;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    public async Task<bool> DeleteClientAsync(int idClient)
    {
        var clientExists = await clientRepository.ClientExistsByIdAsync(idClient);
        if (!clientExists)
            throw new ClientDoesNotExistException(idClient);
        
        var clientHasTrips = await clientRepository.ClientHasTripsAsync(idClient);
        if (clientHasTrips)
            throw new ClientHasTripsException(idClient);
        
        return await clientRepository.DeleteClientAsync(idClient);
    }

    public async Task<bool> CreateClientTripAsync(ClientTripDto clientTrip)
    {
        if (await clientRepository.ClientExistsByPeselAsync(clientTrip.Pesel))
            throw new ClientWithPeselExistsException(clientTrip.Pesel);

        if (await clientRepository.ClientHasThisTripAsync(clientTrip.Pesel, clientTrip.IdTrip))
            throw new ClientWithPeselHasThisTripException(clientTrip.Pesel, clientTrip.IdTrip);

        if (await clientRepository.TripFromPast(clientTrip))
            throw new TripFromThePastException();
        
        return await clientRepository.CreateClientTripAsync(clientTrip);
    }
    
}
