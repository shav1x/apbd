using test1.Entities;
using test1.Exceptions;
using test1.Infrastructure.Repositories.Abstractions;
using test1.Services.Abstractions;

namespace test1.Services;

public class TasksService : ITasksService
{
    private readonly ITasksRepository _tasksRepository;
    
    public TasksService(ITasksRepository tasksRepository)
    {
        _tasksRepository = tasksRepository;
    }
    
    public async Task<Dictionary<string, List<Tasks>>> GetAllTeamMemberTasksAsync(int teamMemberId,
        CancellationToken cancellationToken = default)
    {
        var teamMemberExists = await _tasksRepository.TeamMemberExistsByIdAsync(teamMemberId, cancellationToken);
        if (!teamMemberExists)
        {
            throw new TeamMemberNotFoundException(teamMemberId);
        }
        
        var assigned = await _tasksRepository.GetTasksAssignedToTeamMemberIdAsync(teamMemberId, cancellationToken);
        var created = await _tasksRepository.GetTasksCreatedByTeamMemberIdAsync(teamMemberId, cancellationToken);
        
        return new Dictionary<string, List<Tasks>>
        {
            { "assigned", assigned },
            { "created", created }
        };
    }
}
