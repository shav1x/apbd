namespace tut11.Application.Exceptions;

public class ActorDoesNotExistException(int IdActor) : Exception($"Actor with id {IdActor} does not exist");
