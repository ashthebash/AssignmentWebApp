using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.Security.Claims;

namespace AssignmentWebApp.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        [Route("[controller]/login")]
        public async Task<IActionResult> LoginAsync()
        {
            AuthenticationProperties authProperties = new AuthenticationProperties { RedirectUri = Url.Action("LoginResponse") };
            await Task.Delay(10);
            return Challenge(authProperties);
        }

        
        public async Task<IActionResult> LoginResponseAsync()
        {
            AuthenticateResult result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault().Claims;
            return Json(claims);
        }

        [Route("[controller]/logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToPage("/Index");
        }
    }
}
