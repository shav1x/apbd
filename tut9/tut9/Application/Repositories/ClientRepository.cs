using Microsoft.EntityFrameworkCore;
using tut9.Application.DTOs;
using tut9.Application.Repositories.Interfaces;
using tut9.Core.Models;

namespace tut9.Application.Repositories;

public class ClientRepository(TripContext tripContext) : IClientRepository
{
    
    public async Task<bool> ClientExistsByIdAsync(int idClient)
    {
        return await tripContext.Clients.AnyAsync(c => c.IdClient == idClient);
    }

    public async Task<bool> ClientHasTripsAsync(int idClient)
    {
        return await tripContext.ClientTrips.AnyAsync(ct => ct.IdClient == idClient);
    }

    public async Task<bool> DeleteClientAsync(int idClient)
    {
        var client = await tripContext.Clients.FindAsync(idClient);
        if (client == null)
        {
            return false;
        }

        tripContext.Clients.Remove(client);
        await tripContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ClientExistsByPeselAsync(string pesel)
    {
        return await tripContext.Clients.AnyAsync(c => c.Pesel == pesel);
    }

    public async Task<bool> ClientHasThisTripAsync(string pesel, int idTrip)
    {
        var clientId = await tripContext.Clients.Where(c => c.Pesel == pesel).Select(c => c.IdClient).FirstOrDefaultAsync();
        return await tripContext.ClientTrips.AnyAsync(ct => ct.IdClient == clientId && ct.IdTrip == idTrip);
    }

    public async Task<bool> CreateClientTripAsync(ClientTripDto clientTrip)
    {
        var newClient = new Client
        {
            FirstName = clientTrip.FirstName,
            LastName = clientTrip.LastName,
            Email = clientTrip.Email,
            Telephone = clientTrip.Telephone,
            Pesel = clientTrip.Pesel
        };
        tripContext.Clients.Add(newClient);
        await tripContext.SaveChangesAsync();

        var newClientTrip = new ClientTrip
        {
            IdClient = newClient.IdClient,
            IdTrip = clientTrip.IdTrip,
            RegisteredAt = DateTime.Now,
            PaymentDate = clientTrip.PaymentDate
        };

        tripContext.ClientTrips.Add(newClientTrip);
        await tripContext.SaveChangesAsync();
        return true;
        
    }
    
    public async Task<bool> TripFromPast(ClientTripDto clientTrip)
    {
        var tripDate = await tripContext.Trips.Where(t => t.IdTrip == clientTrip.IdTrip).Select(t => t.DateFrom).FirstOrDefaultAsync();
        return tripDate < DateTime.Now;
    }
    
}
