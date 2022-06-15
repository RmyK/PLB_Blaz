using BlazorApp3.DataModels.Enum;
using BlazorApp3.Pages;
using BlazorApp3.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace BlazorApp3.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    [IgnoreAntiforgeryToken]
    public class RegisterModel : PageModel
    {
        private readonly AuthService authSrv;

        [BindProperty]
        public LoginVM Input { get; set; }

        public string ReturnUrl { get; set; }

        public RegisterModel(AuthService authService)
        {
            authSrv = authService;
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, Input.Email));
                claims.Add(new Claim(ClaimTypes.Email, Input.Email));
                claims.Add(new Claim("Password", Input.Password));
                claims.Add(new Claim(ClaimTypes.Role, nameof(ERole.user)));
                claims.Add(new Claim(ClaimTypes.Role, nameof(ERole.superuser)));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(claimsIdentity);

                authSrv.Users.Add(Input.Email, principal);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return LocalRedirect(returnUrl);
            }
            return Page();
        }

    }
}
