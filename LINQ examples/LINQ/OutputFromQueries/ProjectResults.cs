namespace LINQ.OutputFromQueries;

public class ProjectResults : QueryRunner
{
    public override void Run()
    {
        throw new NotImplementedException();
    }

    private void SelectSingleProperty()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = sourceMovies
            .Where(movie => movie.Name.StartsWith("Iron Man"))
            .Select(movie => movie.Name);

        PrintAll(query);
    }

    private void SelectAnonymousType()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = sourceMovies
            .Where(movie => movie.Name.StartsWith("Iron Man"))
            .Select(movie => new { movie.Name, movie.ReleaseDate.Year });
        
        PrintAll(query);
    }

    private void ProjectToValueTuple()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = sourceMovies
            .Where(movie => movie.Name.StartsWith("Iron Man"))
            .Select(movie => (Title: movie.Name, Year: movie.ReleaseDate.Year));
        
        PrintAll(query);
    }
    
    private void ProjectToOtherType_F()
    {
        var sourceMovies = Repository.GetAllMovies();

        var query = sourceMovies
            .Where(movie => movie.Name.StartsWith("Iron Man"))
            .Select(movie => new MovieTitle(movie.Name, movie.ReleaseDate.Year));
        
        PrintAll(query);
    }
    
    internal record MovieTitle(string Title, int Year)
    {
        public override string ToString() => $"{Title} ({Year})";
    }
}