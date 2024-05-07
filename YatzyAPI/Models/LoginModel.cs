using System.ComponentModel.DataAnnotations;

namespace YatzyAPI.Models;

public class LoginModel
{
    [Required]
    [EmailAddress]
    public string? EmailAddress { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 6)]
    public string? Password { get; set; }
}
