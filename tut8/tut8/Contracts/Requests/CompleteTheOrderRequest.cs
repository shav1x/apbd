using System.ComponentModel.DataAnnotations;

namespace tut8.Contracts.Requests;

public class CompleteTheOrderRequest
{
    [Required]
    public int OrderId { get; set; }
    
    [Required]
    public DateTime FulfilledAt { get; set; } = DateTime.UtcNow;
}