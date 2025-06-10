using Microsoft.AspNetCore.Mvc;
using tut11.Application.Services.Interfaces;

namespace tut11.Presentation.Controllers;

[ApiController]
[Route("api/actors")]
public class ActorsController(IActorService actorService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllActors([FromQuery] string? name, [FromQuery] string? surname)
    {
        var actors = await actorService.GetAllActors(name, surname);
        return Ok(actors);
    }
}
