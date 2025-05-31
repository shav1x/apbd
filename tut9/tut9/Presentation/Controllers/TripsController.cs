using Microsoft.AspNetCore.Mvc;
using tut9.Application.DTOs;
using tut9.Application.Services.Interfaces;
using tut9.Core.Models;

namespace tut9.Presentation.Controllers;

[ApiController]
[Route("api/trips")]
public class TripsController(ITripService tripService, IClientService clientService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(PaginatedResult<GetTripsDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IEnumerable<GetTripsDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTrips(
        [FromQuery(Name = "page")] int? page,
        [FromQuery(Name = "pageSize")] int? pageSize,
        CancellationToken cancellationToken = default)
    {
        if (page is null && pageSize is null)
        {
            var trips = await tripService.GetAllTripsAsync();
            return Ok(trips);
        }

        var paginatedTrips = await tripService.GetPaginatedTripsAsync(page ?? 1, pageSize ?? 10);
        return Ok(paginatedTrips);
    }
    
    [HttpPost("{tripId:int}/clients")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddClientToTrip([FromRoute]int tripId, [FromBody] ClientTripDto clientTrip)
    {
        var isAdded = await clientService.CreateClientTripAsync(clientTrip);
        return CreatedAtAction(nameof(AddClientToTrip), new {tripId, clientTrip.Pesel}, null);
    }
    
}
