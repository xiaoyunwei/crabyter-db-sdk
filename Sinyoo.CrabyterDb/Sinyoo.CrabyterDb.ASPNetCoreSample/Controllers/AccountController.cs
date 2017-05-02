using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Sinyoo.CrabyterDb;
using Sinyoo.CrabyterDb.ASPNetCoreSample.Services;
using Sinyoo.CrabyterDb.ASPNetCoreSample.Models;
using Sinyoo.CrabyterDb.Models;

namespace Sinyoo.CrabyterDb.ASPNetCoreSample.Controllers
{
    public class AccountController : Controller
    {       
        private readonly ICrabyterDbServiceProvider crabyterDbService;

        public AccountController(ICrabyterDbServiceProvider crabyterDbServiceProvider)
        {
            crabyterDbService = crabyterDbServiceProvider;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            bool loginSuccess = await crabyterDbService.LoginAsync(model.UserName, model.Password);

            if (loginSuccess)
            {
                var claims = new List<Claim>
                {
                    new Claim(ConstantDefinitions.AUTH_USER_NAME, crabyterDbService.UserName),
                    new Claim(ConstantDefinitions.AUTH_USER_TOKEN, crabyterDbService.Token)
                };

                var identity = new ClaimsIdentity(claims, ConstantDefinitions.AUTH_TYPE);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.Authentication.SignInAsync(ConstantDefinitions.AUTH_SCHEME_NAME, principal);

                User currentUser = await crabyterDbService.GetCurrentUser();
                HttpContext.Response.Cookies.Append(ConstantDefinitions.COOKIES_REAL_NAME, currentUser.RealName);

                if (returnUrl != null)
                    return LocalRedirect(returnUrl);
                else
                    return Redirect("/");
            }

            ModelState.AddModelError(string.Empty, "用户名或密码无效");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync(ConstantDefinitions.AUTH_SCHEME_NAME);
            await crabyterDbService.LogoutAsync();
            HttpContext.Response.Cookies.Delete(ConstantDefinitions.COOKIES_REAL_NAME);
            return Redirect("/");
        }
    }
}