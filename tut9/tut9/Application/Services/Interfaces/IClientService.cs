using tut9.Application.DTOs;

namespace tut9.Application.Services.Interfaces;

public interface IClientService
{
    Task<bool> DeleteClientAsync(int idClient);
    Task<bool> CreateClientTripAsync(ClientTripDto clientTrip);
}