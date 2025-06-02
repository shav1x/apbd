using Microsoft.AspNetCore.Mvc;
using tut10.Application.Services.Interfaces;

namespace tut10.Presentation.Controllers;

[ApiController]
[Route("api/patient")]
public class PatientController(IPatientService patientService) : ControllerBase
{
    [HttpGet("{idPatient:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPatientAsync([FromRoute] int idPatient)
    {
        var patient = await patientService.GetPatientAsync(idPatient);
        return Ok(patient);
    }
}