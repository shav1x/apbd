namespace LINQ.CheckingContents;

public class AllAny : QueryRunner
{
    public override void Run()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Check if there is at least one item that matches the criteria
    /// </summary>
    private void CheckIfMatchIsPresent()
    {
        var sourceMovies = Repository.GetAllMovies();

        var isBlackWindowPresent = sourceMovies
            .Any(movie => movie.Name.StartsWith("Iron"));

        Console.WriteLine(isBlackWindowPresent);
    }

    /// <summary>
    /// Check if all items match the criteria
    /// </summary>
    private void CheckIsAllItemsMatch()
    {
        var ironManMovies = Repository.GetAllMovies()
            .Where(movie => movie.Name.StartsWith("Iron Man"));

        var areAllIronManEarlyPhases = ironManMovies
            .All(movie => movie.Phase <= 2);

        Console.WriteLine(areAllIronManEarlyPhases);
    }
}