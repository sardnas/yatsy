using Microsoft.AspNetCore.Identity;
using YatzyAPI.Enteties;
using YatzyAPI.Interfaces;
using YatzyAPI.Models;
using YatzyAPI.Responses;

namespace YatzyAPI.Services;

public class UserIdentityService : IUserIdentityService
{
    private UserManager<UserProfileIdentityUser> _userManager;
    public UserIdentityService(UserManager<UserProfileIdentityUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<AppResponse<DefaultResponseItem>> RegisterAsync(RegisterModel model, string userType)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));

        if (model.Password != model.ConfirmPassword)
            return new AppResponse<DefaultResponseItem>
            {
                Message = "Passwords don't match.",
                IsSuccess = false
            };
        
        var identityUser = new UserProfileIdentityUser
        {
            Email = model.EmailAddress,
            UserName = model.EmailAddress,
            UserProfileId = Guid.NewGuid(),
        };

        var result = await _userManager.CreateAsync(identityUser, model.Password);

        if (result.Succeeded)
        {
            return new AppResponse<DefaultResponseItem>
            {
                Message = "User Created",
                IsSuccess = true
            };
                
        }

        return new AppResponse<DefaultResponseItem>
        {
            Message = "User creation error",
            IsSuccess = false,
            Errors = result.Errors.Select(er => er.Description)
        };

    }

    public async Task<AppResponse<DefaultResponseItem>> LoginAsync(LoginModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.EmailAddress);

        if (user == null)
        {
            return new AppResponse<DefaultResponseItem>
            {
                Message = "No user matches this Identity",
                IsSuccess = false,
            };
        }

        var result = await _userManager.CheckPasswordAsync(user, model.Password);
        if (!result)
        {
            return new AppResponse<DefaultResponseItem>
            {
                Message = "Invalid credentials",
                IsSuccess = false,
            };
        }

        string tokenAsString = "add token";

        return new AppResponse<DefaultResponseItem>
        {
            Message = tokenAsString,
            IsSuccess = true,
            ExpireDate = new DateTime() // token.validUntil
        };
    }

}
