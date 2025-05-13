using test1.Entities;

namespace test1.Infrastructure.Repositories.Abstractions;

public interface ITasksRepository
{
    public ValueTask<bool> ProjectExistsByIdAsync(int projectId, CancellationToken cancellationToken = default);
    public ValueTask<bool> TaskTypeExistsByIdAsync(int taskTypeId, CancellationToken cancellationToken = default);
    public ValueTask<bool> TeamMemberExistsByIdAsync(int teamMemberId, CancellationToken cancellationToken = default);
    public Task<List<Tasks>?> GetTasksAssignedToTeamMemberIdAsync(int teamMemberId, CancellationToken cancellationToken = default);
    public Task<List<Tasks>?> GetTasksCreatedByTeamMemberIdAsync(int teamMemberId, CancellationToken cancellationToken = default);
}
