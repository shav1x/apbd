using lec6.Models;
using lec6.Repositories;

namespace lec6.Services;

public class StudentsService
{
    public async Task<List<Student>> GetStudentsAsync()
    {
        var repository = new StudentsRepository();
        var students = repository.GetStudentsAsync(); // select * from students
        var comments = repository.GetCommentsAsync(); // select * from comments
        var posts = repository.GetPostsAsync(); // select * from posts
        
        Task.WaitAll(students, comments, posts);
        
        // 10 s + 4 s + 4 s = 18 s
        // ± 10 s
        //...
        //...

        return null;
    }
}
