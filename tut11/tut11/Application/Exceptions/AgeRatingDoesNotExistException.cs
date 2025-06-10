namespace tut11.Application.Exceptions;

public class AgeRatingDoesNotExistException(int IdAgeRating) : Exception($"Age rating with id {IdAgeRating} does not exist");
