using System.ComponentModel.DataAnnotations;

namespace test1.Contracts.Requests;

public class CreateTaskRequest
{
    [Required]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    public DateTime Deadline { get; set; }
    
    [Required]
    public int IdTeam { get; set; }
    
    [Required]
    public int IdTaskType { get; set; }
    
    [Required]
    public int IdAssignedTo { get; set; }
    
    [Required]
    public int IdCreator { get; set; }
}
