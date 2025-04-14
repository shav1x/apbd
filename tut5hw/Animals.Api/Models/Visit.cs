namespace Animals.Api.Models;

public class Visit
{
    public int id { get; set; }
    public DateTime date { get; set; }
    public int animalId { get; set; }
    public string description { get; set; }
    public decimal price { get; set; }
}
