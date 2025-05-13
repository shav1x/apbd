namespace test1.Contracts.Responses;

public record struct GetTeamMemberResponse
(
    string FirstName,
    string LastName,
    string Email
);
