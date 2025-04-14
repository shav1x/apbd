using LINQ.Data.Models;

namespace LINQ.Where_Order;

public class Order : QueryRunner
{
    public override void Run()
    {
        throw new NotImplementedException();
    }

    private void SingleOrderByDescending()
    {
        var sourceMovies = Repository.GetAllMovies();

        var result = sourceMovies
            .OrderByDescending(x => x.ReleaseDate);
        
        PrintAll(result);
    }

    private void SingleOrderBy()
    {
        var sourceMovies = Repository.GetAllMovies();

        var result = sourceMovies
            .OrderBy(x => x.ReleaseDate);
        
        PrintAll(result);
    }

    private void MultipleOrder()
    {
        var sourceMovies = Repository.GetAllMovies();

        var result = sourceMovies
            .OrderBy(x => x.ReleaseDate.Year)
            .ThenBy(x => x.Name);
        
        PrintAll(result);
    }

    private void OrderByCustomComparer()
    {
        var sourceMovies = Repository.GetAllMovies();

        var result = sourceMovies
            .OrderBy(movie => movie, new MovieComparer());
        
        PrintAll(result);
    }
}

class MovieComparer : IComparer<Movie>
{
    public int Compare(Movie? first, Movie? second)
    {
        // Same instance
        if (ReferenceEquals(first, second)) return 0;
        
        // Null is smaller than everything
        if (first is null) return -1;
        if (second is null) return 1;
        
        // If the years are different, sort by year
        if (first.ReleaseDate.Year < second.ReleaseDate.Year)
            return -1;
        if (first.ReleaseDate.Year > second.ReleaseDate.Year)
            return 1;
        
        // If the years are equal, sort by name
        return string.Compare(first.Name, second.Name, StringComparison.Ordinal);
    }
}