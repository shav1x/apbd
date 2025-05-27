using lec9.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lec9.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private GakkoDbContext _dbContext;

    public StudentsController(GakkoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var students = await _dbContext
                                            .Students
                                            .Where(s => s.LastName.StartsWith("M"))
                                            .OrderBy(s => s.FirstName)
                                            .ThenBy(s => s.LastName)
                                            .ToListAsync(cancellationToken);
        return Ok(students);
    }
    
}
