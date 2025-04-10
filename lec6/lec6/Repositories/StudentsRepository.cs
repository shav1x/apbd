using lec6.Models;

namespace lec6.Repositories;

public class StudentsRepository
{
    public async Task<IEnumerable<Student>> GetStudentsAsync()
    {
        
        await Task.Delay(10000);
        
        var list = new List<Student>();
        list.Add(new Student {FirstName = "John", LastName = "Doe"});
        list.Add(new Student {FirstName = "Jane", LastName = "Doe"});
        
        return list;
        
    }
    
    public async Task<IEnumerable<Student>> GetCommentsAsync()
    {
        
        await Task.Delay(10000);
        
        var list = new List<Student>();
        list.Add(new Student {FirstName = "John", LastName = "Doe"});
        list.Add(new Student {FirstName = "Jane", LastName = "Doe"});
        
        return list;
        
    }
    
    public async Task<IEnumerable<Student>> GetPostsAsync()
    {
        
        await Task.Delay(10000);
        
        var list = new List<Student>();
        list.Add(new Student {FirstName = "John", LastName = "Doe"});
        list.Add(new Student {FirstName = "Jane", LastName = "Doe"});
        
        return list;
        
    }
}
