namespace tut7.Contracts.Responces;

public record struct GetAllTripsResponse(
    int Id,
    string Name,
    string Description,
    DateTime DateFrom,
    DateTime DateTo,
    int MaxPeople,
    List<CountryResponse> Countries);