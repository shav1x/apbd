namespace tut10.Application.DTOs;

public class PrescriptionDto
{
    public required int IdPatient { get; set; }
    public required string FirstName { get; set; } = string.Empty;
    public required string LastName { get; set; } = string.Empty;
    public required DateTime Birthdate { get; set; }
    public required List<MedicamentDto> Medicaments { get; set; } = [];
    public required DateTime Date { get; set; }
    public required DateTime DueDate { get; set; }
}
