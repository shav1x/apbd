using LINQ.Data.Models;

namespace LINQ.Where_Order;

public class Where : QueryRunner
{
    public override void Run()
    {
        SingleCondition();
    }

    private void SingleCondition()
    {
        var sourceMovies = Repository.GetAllMovies();

        var result = sourceMovies
            .Where(movie => movie.Name.Contains("Iron Man"));
        
        PrintAll(result);
    }

    private void SingleFunctionCondition()
    {
        var sourceMovies = Repository.GetAllMovies();

        var result = sourceMovies
            .Where(movie => IsSpiderManMovie(movie));
        
        PrintAll(result);
    }

    private static bool IsSpiderManMovie(Movie movie)
    {
        return movie.Name.Contains("Spider-Man");
    }

    private void MultipleCondition()
    {
        var sourceMovies = Repository.GetAllMovies();
        
        var result = sourceMovies
            .Where(movie => IsSpiderManMovie(movie))
            .Where(movie => movie.ReleaseDate.Year <= 2010);
        
        PrintAll(result);
    }
}