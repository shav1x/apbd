namespace tut11.Core.Data;

public class ActorMovie
{
    // Navigation properties
    public int IdMovie { get; set; }
    public Movie Movie { get; set; }
    // Navigation properties
    public int IdActor { get; set; }
    public Actor Actor { get; set; }

    public required string CharacterName { get; set; }
}
