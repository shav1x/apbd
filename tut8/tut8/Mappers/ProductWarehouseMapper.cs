using tut8.Contracts.Responses;
using tut8.Entities;

namespace tut8.Mappers;

public static class ProductWarehouseMapper
{
    public static GetAllProductWarehouseResponse MapToGetAllProductWarehouseResponse(this ProductWarehouse productWarehouse)
    {
        return new GetAllProductWarehouseResponse
        {
            IdProduct = productWarehouse.Product.Id,
            IdWarehouse = productWarehouse.Warehouse.Id,
            Amount = productWarehouse.Amount,
            CreatedAt = productWarehouse.CreatedAt
        };
    }

    public static ICollection<GetAllProductWarehouseResponse> MapToGetAllProductWarehouseResponse(this ICollection<ProductWarehouse> productWarehouse)
    {
        return productWarehouse.Select(x => x.MapToGetAllProductWarehouseResponse()).ToList();
    }
}