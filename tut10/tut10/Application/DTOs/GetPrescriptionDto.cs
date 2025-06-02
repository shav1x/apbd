namespace tut10.Application.DTOs;

public class GetPrescriptionDto
{
    public required int IdPrescription { get; set; }
    public required DateTime Date { get; set; }
    public required DateTime DueDate { get; set; }
    public required List<MedicamentDto> Medicaments { get; set; } = [];
    public required DoctorDto Doctor { get; set; }
}