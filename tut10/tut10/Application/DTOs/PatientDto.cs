namespace tut10.Application.DTOs;

public class PatientDto
{
    public int IdPatient { get; set; }
    public required string FirstName { get; set; } = string.Empty;
    public required string LastName { get; set; } = string.Empty;
    public required DateTime Birthdate { get; set; }
}
