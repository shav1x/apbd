using lec5.Models;
using Microsoft.AspNetCore.Mvc;

namespace lec5.Controllers;

[ApiController]
[Route("api/{controller}")]
public class StudentsController : ControllerBase
{
    
    private List<Student> _students = new List<Student>();

    public StudentsController()
    {
        _students.Add(new Student() { FirstName = "John", LastName = "Doe", IndexNumber = "s12345" });
        _students.Add(new Student() { FirstName = "Mike", LastName = "Smith", IndexNumber = "s52332" });
        _students.Add(new Student() { FirstName = "Rip", LastName = "Wheeler", IndexNumber = "s75644" });
    }

    [HttpGet]
    public IActionResult GetStudents(string? orderBy)
    {
        return Ok(_students);
    }
    
    [HttpGet("{indexNumber}")]
    public IActionResult GetStudent(string? indexNumber)
    {
        var student = _students.FirstOrDefault(x => x.IndexNumber == indexNumber);
        
        if (student == null)
            return NotFound();
        
        return Ok(student);
    }

    // Just examples below (don't work as intended)
    [HttpPost]
    public IActionResult InsertStudent()
    {
        _students.Add(new Student());
        return Ok(_students);
    }
    
    [HttpPut]
    public IActionResult UpdateStudent()
    {
        return Ok(_students);
    }

    [HttpDelete]
    public IActionResult DeleteStudent()
    {
        return Ok(_students);
    }
    
}
