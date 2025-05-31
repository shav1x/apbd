namespace tut10.Application.DTOs;

public class PrescriptionDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime Birthdate { get; set; }
    public List<MedicamentDto> Medicaments { get; set; } = [];
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}
