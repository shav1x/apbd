using System.ComponentModel.DataAnnotations;

namespace lec9.Models;

public class StudentGroup
{
    [Key]
    public int IdStudentGroup { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    public ICollection<Student> Students { get; set; }
}