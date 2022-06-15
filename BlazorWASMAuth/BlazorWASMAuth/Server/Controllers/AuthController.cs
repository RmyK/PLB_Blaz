using BlazorWASMAuth.Server.DataModels;
using BlazorWASMAuth.Server.Services;
using BlazorWASMAuth.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlazorWASMAuth.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [IgnoreAntiforgeryToken]
    public class AuthController : ControllerBase
    {
        private readonly UserService usrSrv;
        private const string RefreshTokenCookieKey = "TokenCookieKey";

        public AuthController(UserService userService)
        {
            usrSrv = userService;
        }

        [HttpPost("/register")]
        public IActionResult Register(string login, string password)
        {
            var user = new User()
            {
                Email = login,
                UserName = login,
                Password = password,
                SecurityStamp = "securitystamp"
            };

            try
            {
                usrSrv.AddUser(user);
                return Ok();
            }
            catch (Exception)
            {
                return Problem("Cannot register");
            }
        }

        [HttpPost("/login")]
        public LoginResponse Login(LoginDTO dTO)
        {
            var user = usrSrv.LoginUser(dTO.Login, dTO.Password);
            if(user != null)
            {
                string jwt = CreateJWT(user);
                AppendRefreshTokenCookie(user, HttpContext.Response.Cookies);

                return new LoginResponse(true, jwt);
            }
            else
            {
                return LoginResponse.Failed;
            }
        }

        private void AppendRefreshTokenCookie(User user, IResponseCookies cookies)
        {
            var options = new CookieOptions();
            options.HttpOnly = true;
            options.Secure = true;
            options.SameSite = SameSiteMode.Strict;
            options.Expires = DateTime.Now.AddMinutes(60);
            cookies.Append(RefreshTokenCookieKey, user.SecurityStamp, options);
        }

        private string CreateJWT(User user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisIsTheS3cr3TPa$$Phr4s3"));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()));

            var token = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials : credentials
                ) ;
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
