namespace test1.Contracts.Responses;

public record struct GetTasksResponse
(
    string Name,
    string Description,
    DateTime Deadline,
    string ProjectName,
    string TaskTypeName
);