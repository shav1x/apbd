namespace tut8.Exceptions;

public class CreatedAtException() : Exception($"The date of creation of the request should be greater than the date of the creation of the order");