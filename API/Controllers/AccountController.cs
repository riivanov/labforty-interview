using API.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

class AccountController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Login(string returnURL)
    {
        return Ok(
            new
            {
                Message = "Unrecognized user. You must sign in to use this weather service.",
                LoginUrl = Url.ActionLink(
                    action: "",
                    controller: "Account",
                    values: new { ReturnURL = returnURL },
                    protocol: Request.Scheme
                ),
                Schema = "{ \n userName * string \n  email * string($email) \n }"
            }
        );
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        var returnUrl = HttpContext?.Request.Query.FirstOrDefault(r => r.Key == "returnUrl");

        if (user is null)
        {
            return Unauthorized();
        }
        else
        {
            var token = _userManager.GenerateUserTokenAsync(user, "Default", "passwordless-auth");
            var url = Url.ActionLink(
                action: "",
                controller: "LoginRedirect",
                values: new
                {
                    Token = token.Result,
                    Email = model.Email, // Easier to read; not all are inferred
                    ReturnUrl = returnUrl?.Value
                },
                protocol: Request.Scheme
            );
            return Ok(url);
        }
    }
}
