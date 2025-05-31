namespace tut10.Core.Data;

public class Medicament
{
    public int IdMedicament { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Type { get; set; }
}