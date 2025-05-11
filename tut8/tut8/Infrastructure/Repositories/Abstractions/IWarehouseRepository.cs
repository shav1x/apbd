namespace tut8.Infrastructure.Repositories.Abstractions;

public interface IWarehouseRepository
{
    public ValueTask<bool> WarehouseExistsAsync(int warehouseId, CancellationToken cancellationToken = default);
}