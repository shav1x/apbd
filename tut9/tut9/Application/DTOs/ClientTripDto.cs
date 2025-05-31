namespace tut9.Application.DTOs;

public class ClientTripDto
{
    public required string FirstName { get; set; } = string.Empty;
    public required string LastName { get; set; } = string.Empty;
    public required string Email { get; set; } = string.Empty;
    public required string Telephone { get; set; } = string.Empty;
    public required string Pesel { get; set; } = string.Empty;
    public required int IdTrip { get; set; }
    public required string TripName { get; set; } = string.Empty;
    public required DateTime? PaymentDate { get; set; }
}
