using test1.Contracts.Responses;
using test1.Entities;

namespace test1.Mappers;

public static class MapTasksTeamMapper
{
    public static GetTeamMemberTasksResponse MapToResponse(this Dictionary<string, List<Tasks>> tasks)
    {
        var tasksAssigned = tasks["assigned"];
        var assignedTasks = tasksAssigned
            .OrderByDescending(task => task.Deadline)
            .Select(task => new GetTasksResponse(
                task.Name,
                task.Description,
                task.Deadline,
                task.Project.Name,
                task.TaskType.Name
            ))
            .ToList();

        var tasksCreated = tasks["created"];
        var createdTasks = tasksCreated
            .OrderByDescending(task => task.Deadline)
            .Select(task => new GetTasksResponse(
                task.Name,
                task.Description,
                task.Deadline,
                task.Project.Name,
                task.TaskType.Name
            ))
            .ToList();

        var teamMember = tasksAssigned.First().AssignedTo;
        var response = new GetTeamMemberTasksResponse(
            new GetTeamMemberResponse(
                teamMember.FirstName,
                teamMember.LastName,
                teamMember.Email
            ),
            assignedTasks,
            createdTasks
        );

        return response;
    }
}