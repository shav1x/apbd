namespace tut8.Entities;

public class Order : BaseEntity
{
    public Product Product { get; set; } = null!;
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? FulfilledAt { get; set; }
    public List<ProductWarehouse>? Products { get; set; }
}