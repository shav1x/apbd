namespace LINQ.PartialResults;

public class SkipTake : QueryRunner
{
    public override void Run()
    {
        throw new NotImplementedException();
    }

    private void TakeFirstItems()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = 
            from movie in sourceMovies
            where movie.Producers.Count > 1
            select movie;

        var result = query
            .Take(5);

        PrintAll(result);
    }
    
    /// <summary>
    /// Comparing to `Where`extension method, it will stop iterating thought a collection when the first non-match is encountered.
    /// </summary>
    private void TakeMatchingItems()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = 
            from movie in sourceMovies
            where movie.Producers.Count > 1
            select movie;

        var result = query
            .TakeWhile(movie => movie.Phase <= 3);

        PrintAll(result);
    }
    
    private void SkipFirstItems()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = 
            from movie in sourceMovies
            where movie.Producers.Count > 1
            select movie;

        var result = query
            .Skip(5);

        PrintAll(result);
    }
    
    private void GetChunkUsingSkipAndTake()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = 
            from movie in sourceMovies
            where movie.Producers.Count > 1
            select movie;

        var result = query
            .Skip(10)
            .Take(5);

        PrintAll(result);
    }
}