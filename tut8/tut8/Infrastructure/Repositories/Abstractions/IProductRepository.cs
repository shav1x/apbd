namespace tut8.Infrastructure.Repositories.Abstractions;

public interface IProductRepository
{
    public ValueTask<bool> ProductExistsAsync(int productId, CancellationToken cancellationToken = default);
}