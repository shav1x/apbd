namespace tut11.Core.Data;

public class Actor
{
    public int IdActor { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string? Nickname { get; set; }

    public ICollection<ActorMovie> ActorMovies { get; set; } = [];
}