namespace tut8.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public List<Order>? Orders { get; set; }
    public List<ProductWarehouse>? Warehouses { get; set; }
}