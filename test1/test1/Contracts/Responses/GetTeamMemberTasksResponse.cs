namespace test1.Contracts.Responses;

public record struct GetTeamMemberTasksResponse
(
    GetTeamMemberResponse TeamMember,
    List<GetTasksResponse> TasksAssigned,
    List<GetTasksResponse> TasksCreated
);
