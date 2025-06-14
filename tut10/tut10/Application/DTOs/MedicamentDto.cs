namespace tut10.Application.DTOs;

public class MedicamentDto
{
    public required int IdMedicament { get; set; }
    public required string Description { get; set; } = string.Empty;
    public required int Dose { get; set; }
}