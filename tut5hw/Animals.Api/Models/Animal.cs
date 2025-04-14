namespace Animals.Api.Models;

public class Animal
{
    public required int id { get; set; }
    public required string name { get; set; }
    public required string category { get; set; }
    public required decimal weight { get; set; }
    public required string furcolor { get; set; }
}