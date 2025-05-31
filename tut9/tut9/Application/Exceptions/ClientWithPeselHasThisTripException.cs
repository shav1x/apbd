namespace tut9.Application.Exceptions;

public class ClientWithPeselHasThisTripException(string pesel, int tripId) : Exception($"Client with pesel {pesel} already has trip with id {tripId}");