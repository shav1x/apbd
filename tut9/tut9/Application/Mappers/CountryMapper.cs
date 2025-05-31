using tut9.Application.DTOs;
using tut9.Core.Models;

namespace tut9.Application.Mappers;

public static class CountryMapper
{
    public static CountryDto MapToCountryDto(this Country country)
    {
        return new CountryDto
        {
            Name = country.Name
        };
    }
}