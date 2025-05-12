using Microsoft.Data.SqlClient;
using tut8.Exceptions;
using tut8.Infrastructure.Repositories.Abstractions;

namespace tut8.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly string _connectionString;
    
    public OrderRepository(IConfiguration cfg)
    {
        _connectionString = cfg.GetConnectionString("Default") ??
                            throw new ArgumentNullException(nameof(cfg),
                                "Default connection string is missing in configuration");
    }

    public async ValueTask<bool> OrderWasCompletedAsync(int productId, CancellationToken cancellationToken = default)
    {
        const string query = """
                             SELECT COUNT(1)
                             FROM [Order]
                             WHERE IdProduct = @ProductId
                               AND Fulfilled = 1;
                             """;

        await using SqlConnection con = new(_connectionString);
        await using SqlCommand cmd = new(query, con);
        cmd.Parameters.AddWithValue("@ProductId", productId);

        await con.OpenAsync(cancellationToken);
        var count = (int)await cmd.ExecuteScalarAsync(cancellationToken);

        return count > 0;
    }

    public async ValueTask<int> GetOrderIdAsync(int productId, int amount, DateTime createdAt,
        CancellationToken cancellationToken = default)
    {
        const string query = """
                             SELECT TOP 1 Id
                             FROM [Order]
                             WHERE IdProduct = @productId
                               AND Amount = @amount
                               AND CreatedAt < @createdAt;
                             """;

        await using SqlConnection con = new(_connectionString);
        await using SqlCommand cmd = new(query, con);
        cmd.Parameters.AddWithValue("@productId", productId);
        cmd.Parameters.AddWithValue("@amount", amount);
        cmd.Parameters.AddWithValue("@createdAt", createdAt);

        await con.OpenAsync(cancellationToken);
        var result = await cmd.ExecuteScalarAsync(cancellationToken);
        
        if (result == null || result == DBNull.Value)
        {
            throw new InvalidOperationException("Order ID could not be determined because no matching order was found.");
        }

        return Convert.ToInt32(result);
    }


    public async ValueTask<bool> UpdateOrderFulfilledAtAsync(int productId, CancellationToken cancellationToken = default)
    {
        const string query = """
                             UPDATE [Order]
                             SET FulfilledAt = @fulfilledAt
                             WHERE IdProduct = @productId;
                             """;
        
        await using SqlConnection con = new(_connectionString);
        await using SqlCommand cmd = new(query, con);
    
        cmd.Parameters.AddWithValue("@productId", productId);
        cmd.Parameters.AddWithValue("@fulfilledAt", DateTime.UtcNow);

        await con.OpenAsync(cancellationToken);

        var rowsAffected = await cmd.ExecuteNonQueryAsync(cancellationToken);
        
        return rowsAffected == 1;

    }
}
