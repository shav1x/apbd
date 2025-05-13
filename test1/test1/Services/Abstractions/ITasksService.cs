using test1.Entities;

namespace test1.Services.Abstractions;

public interface ITasksService
{
    public Task<Dictionary<string, List<Tasks>>> GetAllTeamMemberTasksAsync(int teamMemberId, CancellationToken cancellationToken = default);
}
