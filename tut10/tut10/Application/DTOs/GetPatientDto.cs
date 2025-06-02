namespace tut10.Application.DTOs;

public class GetPatientDto
{
    public required int IdPatient { get; set; }
    public required string FirstName { get; set; } = string.Empty;
    public required string LastName { get; set; } = string.Empty;
    public required DateTime Birthdate { get; set; }
    public required List<GetPrescriptionDto> Prescriptions { get; set; } = [];
    
}