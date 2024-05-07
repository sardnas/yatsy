using YatzyAPI.Models;
using YatzyAPI.Responses;

namespace YatzyAPI.Interfaces;

public interface IUserIdentityService
{
    Task<AppResponse<DefaultResponseItem>> RegisterAsync(RegisterModel model, string userType);
    Task<AppResponse<DefaultResponseItem>> LoginAsync(LoginModel model);
}
