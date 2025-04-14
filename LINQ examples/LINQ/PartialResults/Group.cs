namespace LINQ.PartialResults;

public class Group : QueryRunner
{
    public override void Run()
    {
        GroupedResults();
    }
    
    private void GroupedResults()
    {
        var sourceMovies = Repository.GetAllMovies();

        var groupedQuery = sourceMovies
            .Where(movie => movie.Producers.Count > 1)
            .GroupBy(
                movie => movie.Phase,
                movie => movie)
            .Where(phase => phase.Key > 2);
        

        foreach (var phase in groupedQuery)
        {
            Console.WriteLine($"Phase {phase.Key}:");
            foreach (var movie in phase)
            {
                Console.WriteLine(movie);
            }
        }
    }
}