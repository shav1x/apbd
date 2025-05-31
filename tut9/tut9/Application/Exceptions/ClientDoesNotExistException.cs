namespace tut9.Application.Exceptions;

public class ClientDoesNotExistException(int Id) : Exception($"Client with id {Id} does not exist");