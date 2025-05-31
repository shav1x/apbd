using tut9.Application.DTOs;
using tut9.Core.Models;

namespace tut9.Application.Repositories.Interfaces;

public interface IClientRepository
{
    Task<bool> ClientExistsByIdAsync(int idClient);
    Task<bool> ClientExistsByPeselAsync(string pesel);
    Task<bool> ClientHasThisTripAsync(string pesel, int idTrip);
    Task<bool> CreateClientTripAsync(ClientTripDto clientTrip);
    Task<bool> TripFromPast(ClientTripDto clientTrip);
    Task<bool> ClientHasTripsAsync(int idClient);
    Task<bool> DeleteClientAsync(int idClient);
}