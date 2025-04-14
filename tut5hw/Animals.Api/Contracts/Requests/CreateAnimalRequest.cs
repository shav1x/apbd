using System.ComponentModel.DataAnnotations;

namespace Animals.Api.Contracts.Requests;

public class CreateAnimalRequest
{
    [Required]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string Category { get; set; } = string.Empty;
    
    [Required]
    public decimal Weight { get; set; } = Decimal.Zero;
    
    [Required]
    public string Furcolor { get; set; } = string.Empty;
}
