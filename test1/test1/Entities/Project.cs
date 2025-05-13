using System.Diagnostics;

namespace test1.Entities;

public class Project : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public DateTime Deadline { get; set; }
    public List<Tasks>? Tasks { get; set; }
}