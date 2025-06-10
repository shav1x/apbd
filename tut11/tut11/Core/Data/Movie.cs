namespace tut11.Core.Data;

public class Movie
{
    public int IdMovie { get; set; }
    
    // Navigation properties
    public int AgeRatingId { get; set; }
    public AgeRating AgeRating { get; set; }
    
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }

    public ICollection<ActorMovie> ActorMovies { get; set; } = [];
}
