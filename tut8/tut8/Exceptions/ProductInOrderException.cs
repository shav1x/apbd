namespace tut8.Exceptions;

public class ProductInOrderException(int productId) : Exception($"The product with id {productId} was specified incorrectly");