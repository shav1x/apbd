using Microsoft.AspNetCore.Mvc;
using tut9.Application.Exceptions;
using tut9.Application.Services.Interfaces;

namespace tut9.Presentation.Controllers;

[ApiController]
[Route("api/clients")]
public class ClientController(IClientService clientService) : ControllerBase
{
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteClient(
        int id,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var isRemoved = await clientService.DeleteClientAsync(id);
            return isRemoved ? NoContent() : NotFound();
        }
        catch (ClientHasTripsException e)
        {
            return BadRequest(e.Message);
        }
    }
}
