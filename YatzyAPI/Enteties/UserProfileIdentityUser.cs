using Microsoft.AspNetCore.Identity;

namespace YatzyAPI.Enteties;

public class UserProfileIdentityUser : IdentityUser
{
    public Guid UserProfileId { get; set; }
}
