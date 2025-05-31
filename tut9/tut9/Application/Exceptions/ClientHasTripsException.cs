namespace tut9.Application.Exceptions;

public class ClientHasTripsException(int Id) : Exception($"Client with id {Id} has trips");