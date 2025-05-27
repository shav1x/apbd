using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lec9.Models;

public class Student
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    public DateTime BirthDate { get; set; }

    public int IdStudentGroup { get; set; }

    [ForeignKey(nameof(IdStudentGroup))]
    public StudentGroup StudentGroup { get; set; }
}
