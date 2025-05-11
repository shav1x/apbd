namespace tut8.Infrastructure.Repositories.Abstractions;

public interface IOrderRepository
{
    // In the Product_Warehouse table
    public ValueTask<bool> OrderWasCompletedAsync(int orderId, CancellationToken cancellationToken = default);
    
    // In the Order table with such idProduct and Amount; check the CreatedAt value
    public ValueTask<int> GetOrderIdAsync(int productId, int amount, DateTime createdAt,
        CancellationToken cancellationToken = default);
    
    // Update fulfilledAt value
    public ValueTask<bool> UpdateOrderFulfilledAtAsync(int orderId,
        CancellationToken cancellationToken = default);
}