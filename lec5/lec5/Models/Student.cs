using System.ComponentModel.DataAnnotations;

namespace lec5.Models;

public class Student
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IndexNumber { get; set; }
}
