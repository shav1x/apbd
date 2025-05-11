using tut8.Entities;

namespace tut8.Infrastructure.Repositories.Abstractions;

public interface IProductWarehouseRepository
{
    public Task<ICollection<ProductWarehouse>> GetProductWarehousesAsync(CancellationToken cancellationToken);
    public Task<int> CreateProductWarehouseAsync(ProductWarehouse productWarehouse, CancellationToken cancellationToken);
}