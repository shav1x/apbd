namespace tut3.Exceptions;

public class OverfillException(string message) : Exception(message); // "overrides" the Exception message field