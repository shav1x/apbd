namespace tut8.Exceptions;

public class ProductDoesNotExistException(int productId) : Exception($"Product with id {productId} does not exist");