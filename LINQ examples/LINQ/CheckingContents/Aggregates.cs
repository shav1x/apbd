namespace LINQ.CheckingContents;

public class Aggregates : QueryRunner
{
    public override void Run()
    {
        throw new NotImplementedException();
    }

    private void MinimumValue()
    {
        var sourceMovies = Repository.GetAllMovies();

        var firstReleaseDate = sourceMovies
            .Min(movie => movie.ReleaseDate);
        
        Console.WriteLine(firstReleaseDate);
    }
    
    private void MinimumItem()
    {
        var sourceMovies = Repository.GetAllMovies();

        var firstMovie = sourceMovies
            .MinBy(movie => movie.ReleaseDate);
        
        Console.WriteLine(firstMovie);
    }

    private void MaximumValue()
    {
        var sourceMovies = Repository.GetAllMovies();

        var lastReleaseDate = sourceMovies
            .Where(movie => movie.ReleaseDate < DateOnly.FromDateTime(DateTime.Now))
            .Max(movie => movie.ReleaseDate);
        
        Console.WriteLine(lastReleaseDate);
    }
    
    private void MaximumItem()
    {
        var sourceMovies = Repository.GetAllMovies();

        var lastMovie = sourceMovies
            .Where(movie => movie.ReleaseDate < DateOnly.FromDateTime(DateTime.Now))
            .MaxBy(movie => movie.ReleaseDate);
        
        Console.WriteLine(lastMovie);
    }
    
    private void AverageValue()
    {
        var sourceMovies = Repository.GetAllMovies();

        var averageProducers = sourceMovies
            .Average(movie => movie.Producers.Count);
        
        Console.WriteLine(averageProducers);
    }
    
    private void SumValue()
    {
        var sourceMovies = Repository.GetAllMovies();

        var totalProducers = sourceMovies
            .Sum(movie => movie.Producers.Count);
        
        Console.WriteLine(totalProducers);
    }
    
    private void CountItems()
    {
        var sourceMovies = Repository.GetAllMovies();

        var numberOfMovies = sourceMovies
            .Count();
        
        Console.WriteLine(numberOfMovies);
    }
    
    private void AggregateFunctionsWithGroupBy()
    {
        var sourceMovies = Repository.GetAllMovies();

        var groupedQuery = sourceMovies
            .Where(movie => movie.Producers.Count > 1)
            .GroupBy(
                movie => movie.Phase,
                movie => movie)
            .Where(phase => phase.Key > 2)
            .Select(group => new
            {
                Movies = group,
                LastMovie = group.Max(film => film.ReleaseDate)
            } );
        

        foreach (var phase in groupedQuery)
        {
            Console.WriteLine($"PHASE {phase.Movies.Key} (until {phase.LastMovie}):");
            foreach (var movie in phase.Movies)
            {
                Console.WriteLine(movie);
            }
        }
    }
}