using Microsoft.Data.SqlClient;
using test1.Infrastructure.Repositories.Abstractions;
using test1.Entities;

namespace test1.Infrastructure.Repositories;

public class TasksRepository : ITasksRepository
{
    private readonly string _connectionString;

    public TasksRepository(IConfiguration cfg)
    {
        _connectionString = cfg.GetConnectionString("Default") ??
                            throw new ArgumentNullException(nameof(cfg),
                                "Default connection string is missing in configuration");
    }

    public async ValueTask<bool> TeamMemberExistsByIdAsync(int teamMemberId, CancellationToken cancellationToken = default)
    {
        const string query = """
                             SELECT 
                                 IIF(EXISTS (SELECT 1 FROM TeamMember 
                                         WHERE TeamMember.IdTeamMember = @teamMemberId), 1, 0) AS TeamMemberExists;   
                             """;

        await using SqlConnection con = new(_connectionString);
        await using SqlCommand cmd = new(query, con);
        await con.OpenAsync(cancellationToken);
        cmd.Parameters.AddWithValue("@teamMemberId", teamMemberId);

        var result = (int)await cmd.ExecuteScalarAsync(cancellationToken);
        return result == 1;
    }

    public async ValueTask<bool> TaskTypeExistsByIdAsync(int taskTypeId, CancellationToken cancellationToken = default)
    {
        const string query = """
                             SELECT 
                                 IIF(EXISTS (SELECT 1 FROM TaskType 
                                         WHERE TaskType.IdTaskType = @taskTypeId), 1, 0) AS TaskTypeExists;   
                             """;

        await using SqlConnection con = new(_connectionString);
        await using SqlCommand cmd = new(query, con);
        await con.OpenAsync(cancellationToken);
        cmd.Parameters.AddWithValue("@taskTypeId", taskTypeId);

        var result = (int)await cmd.ExecuteScalarAsync(cancellationToken);
        return result == 1;
    }

    public async ValueTask<bool> ProjectExistsByIdAsync(int projectId, CancellationToken cancellationToken = default)
    {
        const string query = """
                             SELECT 
                                 IIF(EXISTS (SELECT 1 FROM Project 
                                         WHERE Project.IdProject = @projectId), 1, 0) AS ProjectExists;   
                             """;

        await using SqlConnection con = new(_connectionString);
        await using SqlCommand cmd = new(query, con);
        await con.OpenAsync(cancellationToken);
        cmd.Parameters.AddWithValue("@projectId", projectId);

        var result = (int)await cmd.ExecuteScalarAsync(cancellationToken);
        return result == 1;
    }

    public async Task<List<Tasks>?> GetTasksAssignedToTeamMemberIdAsync(int teamMemberId,
        CancellationToken cancellationToken = default)
    {
        List<Tasks> tasks = new();

        const string query = """
                                 SELECT 
                                     t.IdTask,
                                     t.Name,
                                     t.Description,
                                     t.Deadline,
                                     p.IdProject,
                                     p.Name AS ProjectName,
                                     p.Deadline AS ProjectDeadline,
                                     tt.IdTaskType,
                                     tt.Name AS TaskTypeName,
                                     assigned.IdTeamMember AS AssignedToId,
                                     assigned.FirstName AS AssignedToFirstName,
                                     assigned.LastName AS AssignedToLastName,
                                     assigned.Email AS AssignedToEmail,
                                     creator.IdTeamMember AS CreatorId,
                                     creator.FirstName AS CreatorFirstName,
                                     creator.LastName AS CreatorLastName,
                                     creator.Email AS CreatorEmail
                                 FROM Task t
                                 LEFT JOIN Project p ON t.IdProject = p.IdProject
                                 LEFT JOIN TaskType tt ON t.IdTaskType = tt.IdTaskType
                                 LEFT JOIN TeamMember assigned ON t.IdAssignedTo = assigned.IdTeamMember
                                 LEFT JOIN TeamMember creator ON t.IdCreator = creator.IdTeamMember
                                 WHERE t.IdAssignedTo = @teamMemberId;
                             """;

        await using SqlConnection con = new(_connectionString);
        await using SqlCommand command = new(query, con);
        command.Parameters.AddWithValue("@teamMemberId", teamMemberId);

        await con.OpenAsync(cancellationToken);
        await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);

        while (await reader.ReadAsync(cancellationToken))
        {
            var task = new Tasks
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = reader.GetString(2),
                Deadline = reader.GetDateTime(3),
                Project = new Project
                {
                    Id = reader.GetInt32(4),
                    Name = reader.GetString(5),
                    Deadline = reader.GetDateTime(6)
                },
                TaskType = new TaskType
                {
                    Id = reader.GetInt32(7),
                    Name = reader.GetString(8)
                },
                AssignedTo = new TeamMember
                {
                    Id = reader.GetInt32(9),
                    FirstName = reader.GetString(10),
                    LastName = reader.GetString(11),
                    Email = reader.GetString(12)
                },
                Creator = new TeamMember
                {
                    Id = reader.GetInt32(13),
                    FirstName = reader.GetString(14),
                    LastName = reader.GetString(15),
                    Email = reader.GetString(16)
                }
            };

            tasks.Add(task);
        }

        return tasks;
    }

    public async Task<List<Tasks>?> GetTasksCreatedByTeamMemberIdAsync(int teamMemberId,
        CancellationToken cancellationToken = default)
    {
        List<Tasks> tasks = new();

        const string query = """
                                 SELECT 
                                 t.IdTask,
                                 t.Name,
                                 t.Description,
                                 t.Deadline,
                                 p.IdProject,
                                 p.Name AS ProjectName,
                                 p.Deadline AS ProjectDeadline,
                                 tt.IdTaskType,
                                 tt.Name AS TaskTypeName,
                                 assigned.IdTeamMember AS AssignedToId,
                                 assigned.FirstName AS AssignedToFirstName,
                                 assigned.LastName AS AssignedToLastName,
                                 assigned.Email AS AssignedToEmail,
                                 creator.IdTeamMember AS CreatorId,
                                 creator.FirstName AS CreatorFirstName,
                                 creator.LastName AS CreatorLastName,
                                 creator.Email AS CreatorEmail
                             FROM Task t
                             LEFT JOIN Project p ON t.IdProject = p.IdProject
                             LEFT JOIN TaskType tt ON t.IdTaskType = tt.IdTaskType
                             LEFT JOIN TeamMember assigned ON t.IdAssignedTo = assigned.IdTeamMember
                             LEFT JOIN TeamMember creator ON t.IdCreator = creator.IdTeamMember
                             WHERE t.IdCreator = @teamMemberId;
                             """;

        await using SqlConnection con = new(_connectionString);
        await using SqlCommand command = new(query, con);
        command.Parameters.AddWithValue("@teamMemberId", teamMemberId);

        await con.OpenAsync(cancellationToken);
        await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);

        while (await reader.ReadAsync(cancellationToken))
        {
            var task = new Tasks
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = reader.GetString(2),
                Deadline = reader.GetDateTime(3),
                Project = new Project
                {
                    Id = reader.GetInt32(4),
                    Name = reader.GetString(5),
                    Deadline = reader.GetDateTime(6)
                },
                TaskType = new TaskType
                {
                    Id = reader.GetInt32(7),
                    Name = reader.GetString(8)
                },
                AssignedTo = new TeamMember
                {
                    Id = reader.GetInt32(9),
                    FirstName = reader.GetString(10),
                    LastName = reader.GetString(11),
                    Email = reader.GetString(12)
                },
                Creator = new TeamMember
                {
                    Id = reader.GetInt32(13),
                    FirstName = reader.GetString(14),
                    LastName = reader.GetString(15),
                    Email = reader.GetString(16)
                }
            };

            tasks.Add(task);
        }

        return tasks;
    }
}
