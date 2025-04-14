using LINQ.Data.Models;

namespace LINQ.OutputFromQueries;

public class GetAllResults : QueryRunner
{
    public override void Run()
    {
        throw new NotImplementedException();
    }
    
    private void ResultAsGenericList()
    {
        var sourceMovies = Repository.GetAllMovies();
        
        var query = sourceMovies
            .Where(IsSpiderManMovie);

        var result = query.ToList();

        PrintAll(result);
    }
    
    private void ResultAsArray()
    {
        var sourceMovies = Repository.GetAllMovies();
        
        var query = sourceMovies
            .Where(IsSpiderManMovie);

        var result = query.ToArray();

        PrintAll(result);
    }
    
    private void ResultAsDictionary()
    {
        var sourceMovies = Repository.GetAllMovies();
        
        var query = sourceMovies
            .Where(IsSpiderManMovie);

        var result = query.ToDictionary(
            movie => movie.MovieId,
            movie => movie.Name);

        foreach (var movieId in result.Keys)
        {
            Console.WriteLine(result[movieId]);
        }
    }
    
    private static bool IsSpiderManMovie(Movie movie)
    {
        return movie.Name.Contains("Spider-Man");
    }
}