using System.Reflection.Metadata.Ecma335;

namespace test1.Entities;

public class TeamMember : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<Tasks>? Tasks { get; set; }
}