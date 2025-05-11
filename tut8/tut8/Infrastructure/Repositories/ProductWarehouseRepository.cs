using Microsoft.Data.SqlClient;
using tut8.Entities;
using tut8.Infrastructure.Repositories.Abstractions;

namespace tut8.Infrastructure.Repositories;

public class ProductWarehouseRepository : IProductWarehouseRepository
{
    private readonly string _connectionString;

    public ProductWarehouseRepository(IConfiguration cfg)
    {
        _connectionString = cfg.GetConnectionString("Default") ??
                            throw new ArgumentNullException(nameof(cfg),
                                "Default connection string is missing in configuration");
    }

    public async Task<int> CreateProductWarehouseAsync(ProductWarehouse productWarehouse,
        CancellationToken cancellationToken = default)
    {
        const string query = """
                             INSERT INTO Product_Warehouse (ProductID, WarehouseID, OrderID, Amount, Price, CreatedAt)
                             VALUES(@ProductID, @WarehouseID, @OrderID, @Amount, @Price, @CreatedAt);
                             SELECT SCOPE_IDENTITY();
                             """;
        
        await using SqlConnection con = new(_connectionString);
        await using SqlCommand command = new SqlCommand(query, con);
        await con.OpenAsync(cancellationToken);
        
        command.Parameters.AddWithValue("@idProduct", productWarehouse.Product?.Id);
        command.Parameters.AddWithValue("@idWarehouse", productWarehouse.Warehouse?.Id);
        command.Parameters.AddWithValue("@idOrder", productWarehouse.Order?.Id);
        command.Parameters.AddWithValue("@Amount", productWarehouse.Amount);
        command.Parameters.AddWithValue("@Price", productWarehouse.Price);
        command.Parameters.AddWithValue("@CreatedAt", productWarehouse.CreatedAt);
        
        var result = await command.ExecuteScalarAsync(cancellationToken);
        
        return Convert.ToInt32(result);

    }

    public async Task<ICollection<ProductWarehouse>> GetProductWarehousesAsync(CancellationToken cancellationToken)
    {
        const string query = """
                             SELECT IdProduct, IdWarehouse, Amount, CreatedAt
                             FROM Product_Warehouse;
                             """;

        var productWarehouses = new List<ProductWarehouse>();

        await using SqlConnection connection = new(_connectionString);
        await using SqlCommand command = new(query, connection);

        await connection.OpenAsync(cancellationToken);

        await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            var productWarehouse = new ProductWarehouse
            {
                Product = new Product
                {
                    Id = reader.GetInt32(reader.GetOrdinal("IdProduct")),
                },
                Warehouse = new Warehouse
                {
                    Id = reader.GetInt32(reader.GetOrdinal("IdWarehouse")),
                },
                Amount = reader.GetInt32(reader.GetOrdinal("Amount")),
                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
            };

            productWarehouses.Add(productWarehouse);
        }

        return productWarehouses;


    }
    
}
