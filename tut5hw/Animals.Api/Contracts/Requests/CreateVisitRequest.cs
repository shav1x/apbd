using System.ComponentModel.DataAnnotations;

namespace Animals.Api.Contracts.Requests;

public class CreateVisitRequest
{
    [Required]
    public DateTime Date { get; set; }

    [Required] public int AnimalId { get; set; }
    
    [Required]
    [MinLength(1, ErrorMessage = "Description must not be empty.")]
    public string Description { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; }
}
