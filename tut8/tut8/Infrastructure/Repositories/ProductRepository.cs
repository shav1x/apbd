using Microsoft.Data.SqlClient;
using tut8.Infrastructure.Repositories.Abstractions;

namespace tut8.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly string _connectionString;
    
    public ProductRepository(IConfiguration cfg)
    {
        _connectionString = cfg.GetConnectionString("Default") ??
                            throw new ArgumentNullException(nameof(cfg),
                                "Default connection string is missing in configuration");
    }

    public async ValueTask<bool> ProductExistsAsync(int productId, CancellationToken cancellationToken = default)
    {
        const string query = """
                             SELECT 
                                 IIF(EXISTS (SELECT 1 FROM Product 
                                         WHERE Product.idProduct = @productId), 1, 0) AS ProductExists;   
                             """;
        
        await using SqlConnection con = new(_connectionString);
        await using SqlCommand cmd = new(query, con);
        await con.OpenAsync(cancellationToken);
        cmd.Parameters.AddWithValue("@productId", productId);

        var result = (int)await cmd.ExecuteScalarAsync(cancellationToken);
        
        return result == 1;
        
    }
    
}