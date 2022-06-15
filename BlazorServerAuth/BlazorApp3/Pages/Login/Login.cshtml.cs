using BlazorApp3.Pages;
using BlazorApp3.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace BlazorApp3.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    [IgnoreAntiforgeryToken]
    public class LoginModel : PageModel
    {
        private readonly AuthService authSrv;

        [BindProperty]
        public LoginVM Input { get; set; }

        public string? ReturnUrl { get; set; }


        public LoginModel(AuthService authService)
        {
            authSrv = authService;
            Input = new LoginVM();
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if(ModelState.IsValid)
            {
                authSrv.Users.TryGetValue(Input.Email, out ClaimsPrincipal principal);

                if(principal == null)
                {
                    ModelState.AddModelError(string.Empty, "Utilisateur non inconnu");
                    return Page();
                }

                var identity = principal.Identity as ClaimsIdentity;
                var username = identity.FindFirst(ClaimTypes.Name)?.Value;
                var password = identity.FindFirst("Password")?.Value;

                if(username == Input.Email && password == Input.Password)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(nameof(LoginVM.Email), "Login ou mot de passe incorrect");
                    ModelState.AddModelError(nameof(LoginVM.Password), "Login ou mot de passe incorrect");
                }
            }
            return Page();
        }
    }
}
