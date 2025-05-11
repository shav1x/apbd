namespace tut8.Exceptions;

public class WarehouseDoesNotExistException(int warehouseId) : Exception($"Warehouse with id {warehouseId} does not exist");