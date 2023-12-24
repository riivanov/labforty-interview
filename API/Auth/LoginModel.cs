using System.ComponentModel.DataAnnotations;

namespace API.Auth;

public class LoginModel
{
    public string? UserName { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }
}
