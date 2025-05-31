using tut9.Application.DTOs;
using tut9.Core.Models;

namespace tut9.Application.Mappers;

public static class ClientMapper
{
    public static ClientDto MapToCountryDto(this Client client)
    {
        return new ClientDto
        {
            FirstName = client.FirstName,
            LastName = client.LastName
        };
    }
}