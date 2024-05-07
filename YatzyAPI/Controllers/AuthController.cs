using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YatzyAPI.Interfaces;
using YatzyAPI.Models;

namespace YatzyAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserIdentityService _userIdentityService;

    public AuthController(IUserIdentityService userIdentityService)
    {
        _userIdentityService = userIdentityService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            var userResponse = await _userIdentityService.RegisterAsync(model, "user");
            if (!userResponse.IsSuccess)
            {
                return BadRequest(userResponse);
            }

            return Ok(userResponse);
        }

        return BadRequest("Something went wrong...");
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _userIdentityService.LoginAsync(model);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        return BadRequest("No valid request");
    }
}

