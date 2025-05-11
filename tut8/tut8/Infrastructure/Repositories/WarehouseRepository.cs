using Microsoft.Data.SqlClient;
using tut8.Infrastructure.Repositories.Abstractions;

namespace tut8.Infrastructure.Repositories;

public class WarehouseRepository : IWarehouseRepository
{
    private readonly string _connectionString;
    
    public WarehouseRepository(IConfiguration cfg)
    {
        _connectionString = cfg.GetConnectionString("Default") ??
                            throw new ArgumentNullException(nameof(cfg),
                                "Default connection string is missing in configuration");
    }

    public async ValueTask<bool> WarehouseExistsAsync(int warehouseId, CancellationToken cancellationToken = default)
    {
        const string query = """
                             SELECT 
                             IIF(EXISTS (SELECT 1 FROM Warehouse 
                                     WHERE Warehouse.idWarehouse = @warehouseId), 1, 0) AS WarehouseExists;
                             """;
        
        await using SqlConnection con = new(_connectionString);
        await using SqlCommand cmd = new(query, con);
        await con.OpenAsync(cancellationToken);
        cmd.Parameters.AddWithValue("@warehouseId", warehouseId);

        var result = (int)await cmd.ExecuteScalarAsync(cancellationToken);
        
        return result == 1;
        
    }
    
}