namespace tut10.Application.DTOs;

public class GetMedicamentDto
{
    public required int IdMedicament { get; set; }
    public required string Name { get; set; } = string.Empty;
    public required GetDoseDto Dose { get; set; }
    public required string Description { get; set; } = string.Empty;
}