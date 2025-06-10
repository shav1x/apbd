using Microsoft.AspNetCore.Mvc;
using tut10.Application.DTOs;
using tut10.Application.Services.Interfaces;

namespace tut10.Presentation.Controllers;

[ApiController]
[Route("api/prescription")]
public class PrescriptionController(IPrescriptionService prescriptionService) : ControllerBase
{
    [HttpPost("{idDoctor:int}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreatePrescriptionAsync([FromBody] PrescriptionDto prescriptionDto, [FromRoute] int idDoctor)
    {
        var isAdded = await prescriptionService.CreatePrescriptionAsync(prescriptionDto, idDoctor);
        return Ok();
    }
}
