using System.ComponentModel.DataAnnotations;

namespace User.MinimalApi.Contracts.Requests;

public class UpdateUserRequest
{
    [Required]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "Full name must be between 5 and 50 characters")]
    public string FullName { get; set; } = string.Empty;
    
    [StringLength(50, MinimumLength = 5, ErrorMessage = "Email must be between 5 and 50 characters")]
    public string Email { get; set; } = string.Empty;
}
