using System.ComponentModel.DataAnnotations;

namespace Users.Api.Contracts.Requests;

public class UpdateUserRequest
{
    [Required]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "Full name must be between 5 and 50 characters")]
    public string FullName { get; set; } = string.Empty;
    
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}
