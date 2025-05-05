namespace tut7.Exceptions;

public class ClientWithPeselNumberExistsException(string pesel) : Exception($"Client with {pesel} already exists");