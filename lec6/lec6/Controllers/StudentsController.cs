using lec6.Models;
using lec6.Services;
using Microsoft.AspNetCore.Mvc;

namespace lec6.Controllers;

[ApiController]
[Route("students")]
public class StudentsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetStudentsAsync()
    {
        var service = new StudentsService();
        var students = await service.GetStudentsAsync();
        return Ok(students);
    }
}
