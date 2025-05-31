namespace tut9.Application.Exceptions;

public class ClientWithPeselExistsException(string pesel) : Exception($"Client with pesel {pesel} already exists");