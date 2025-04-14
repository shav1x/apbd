namespace LINQ.PartialResults;

public class Chunks : QueryRunner
{
    public override void Run()
    {
        throw new NotImplementedException();
    }
    
    private void SimpleChunks()
    {
        var sourceMovies = Repository.GetAllMovies();
        
        var chunks = sourceMovies.Chunk(5);

        foreach (var chunk in chunks)
        {
            Console.WriteLine("CHUNK:");
            foreach (var movie in chunk)
            {
                Console.WriteLine(movie);
            }
            Console.WriteLine(string.Empty);
        }
    }
    
    private void ChunksWithIndexes()
    {
        var sourceMovies = Repository.GetAllMovies();
        
        var chunks = sourceMovies.Chunk(5)
            .Select((chunk, index) => new { Movies = chunk, Number = index + 1 });
        
        foreach (var chunk in chunks)
        {
            Console.WriteLine($"CHUNK {chunk.Number}:");
            foreach (var movie in chunk.Movies)
            {
                Console.WriteLine(movie);
            }
            Console.WriteLine(string.Empty);
        }
    }
}