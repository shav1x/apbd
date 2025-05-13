namespace test1.Exceptions;

public class TeamMemberNotFoundException(int id) : Exception($"Team member with id {id} not found");