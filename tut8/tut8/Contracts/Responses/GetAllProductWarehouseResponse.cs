using tut8.Entities;

namespace tut8.Contracts.Responses;

public record struct GetAllProductWarehouseResponse(
    int IdProduct,
    int IdWarehouse,
    int Amount,
    DateTime CreatedAt);