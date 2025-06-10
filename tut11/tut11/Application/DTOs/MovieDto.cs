using tut11.Core.Data;

namespace tut11.Application.DTOs;

public class MovieDto
{
    public required string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public required AgeRating AgeRating { get; set; }
    public required List<ActorDto>? Actors { get; set; } = [];
}
