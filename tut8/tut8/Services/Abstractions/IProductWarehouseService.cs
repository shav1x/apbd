using tut8.Contracts.Requests;
using tut8.Contracts.Responses;

namespace tut8.Services.Abstractions;

public interface IProductWarehouseService
{
    public Task<int> CreateProductWarehouseAsync(AddProductToWarehouseRequest productWarehouse, CancellationToken cancellationToken);
    Task<ICollection<GetAllProductWarehouseResponse>> GetAllProductWarehouseAsync(CancellationToken cancellationToken);
}