namespace LINQ.OutputFromQueries;

public class GetSingleItem : QueryRunner
{
    public override void Run()
    {
        throw new NotImplementedException();
    }

    private void GetFirstItem()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = sourceMovies
            .Where(movie => movie.Name.StartsWith("Spider-Man"));

        var result = query.First();
        
        Print(result);
    }

    private void GetFirstItemWithPredicate()
    {
        var sourceMovies = Repository.GetAllMovies();

        var result = sourceMovies
            .First(movie => movie.Name.StartsWith("Spider-Nam"));
        
        Print(result);
    }

    private void GetFirstItemOrDefault()
    {
        var sourceMovies = Repository.GetAllMovies();

        var result = sourceMovies
            .FirstOrDefault(movie => movie.Name.StartsWith("Batman"));
        
        Print(result);
    }

    private void ExpectSingleMatch()
    {
        var sourceMovies = Repository.GetAllMovies();

        var result = sourceMovies
            .Single(movie => movie.Name.StartsWith("Spider-Man: Homecoming"));
        
        Print(result);
    }
    
    // OVERVIEW:
    //
    // METHOD          | RETURNS     | NO MATCH   | 2+ MATCHES | COMMENTS
    // ----------------+-------------+------------+------------+-------------------------------------------------
    // First           | First match | Throws     | OK         | Stops after first match
    // Last            | Last match  | Throws     | OK         | May iterate entire source
    // Single          | First match | Throws     | Throws     | May iterate entire source, or until second match
    // FirsOrDefault   | First match | default(T) | OK         | Stops after first match
    // LastOrDefault   | Last match  | default(T) | OK         | May iterate entire source
    // SingleOrDefault | First match | default(T) | Throws     | May iterate entire source, or until second match
}