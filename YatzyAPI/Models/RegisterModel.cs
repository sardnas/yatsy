using System.ComponentModel.DataAnnotations;

namespace YatzyAPI.Models;

[Serializable]
public class RegisterModel
{
    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    [Required]
    public string ConfirmPassword { get; set; } = null!;

}
