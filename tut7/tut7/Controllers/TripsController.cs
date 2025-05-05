using Microsoft.AspNetCore.Mvc;
using tut7.Contracts.Responces;
using tut7.Mappers;
using tut7.Services.Abstractions;

namespace tut7.Controllers;

[ApiController]
[Route("api/trips")]
public class TripsController : ControllerBase
{
    private readonly ITripService _tripService;

    public TripsController(ITripService tripService)
    {
        _tripService = tripService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ICollection<GetAllTripsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllTripsAsync(CancellationToken token)
    {
        var trips = await _tripService.GetAllTripsAndCountriesAsync(token);

        return Ok(trips.MapToGetAllTripsResponse());
    }
}