using Microsoft.AspNetCore.Mvc;
using tut11.Application.DTOs;
using tut11.Application.Exceptions;
using tut11.Application.Services.Interfaces;

namespace tut11.Presentation.Controllers;

[ApiController]
[Route("api/movies")]
public class MovieController(IMovieService movieService) : ControllerBase
{
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateMovie([FromBody] MovieDto movieDto)
    {
        try
        {
            await movieService.CreateMovie(movieDto);
            return CreatedAtAction(nameof(CreateMovie), movieDto);
        }
        catch (ActorsNotProvidedException ex)
        {
            return BadRequest(ex.Message);
        }
       
    }
    
}
