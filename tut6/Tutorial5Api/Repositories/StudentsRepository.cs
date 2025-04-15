using Lecture5.Models;

namespace Lecture5.Repositories;

public class StudentsRepository
{
    public async Task<IEnumerable<Student>> GetStudents()
    {
        Thread.Sleep(2000); 
        
        var students = new List<Student>();
        
        students.Add(new Student{IndexNumber = "s1234", FirstName = "John", LastName = "Doe" });
        students.Add(new Student{IndexNumber = "s1235", FirstName = "Jane", LastName = "Doe" });
        students.Add(new Student{IndexNumber = "s1236", FirstName = "Jane", LastName = "Doe" });
       
        return students; 
    }
}