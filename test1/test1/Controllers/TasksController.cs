using Microsoft.AspNetCore.Mvc;
using test1.Contracts.Responses;
using test1.Mappers;
using test1.Services.Abstractions;

namespace test1.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly ITasksService _tasksService;
    
    public TasksController(ITasksService tasksService)
    {
        _tasksService = tasksService;
    }
    
    [HttpGet("{teamMemberId:int}")]
    [ProducesResponseType(typeof(GetTeamMemberTasksResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<GetTeamMemberTasksResponse>> GetTeamMemberTasksAsync([FromRoute] int teamMemberId)
    {
        var result = await _tasksService.GetAllTeamMemberTasksAsync(teamMemberId);
        
        return Ok(result.MapToResponse());
    }
    
}