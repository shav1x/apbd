namespace tut8.Entities;

public class ProductWarehouse : BaseEntity
{
    public Product Product { get; set; } = null!;
    public Warehouse Warehouse { get; set; } = null!;
    public Order Order { get; set; } = null!;
    public int Amount { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
}