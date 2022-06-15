using System.Security.Claims;

namespace BlazorWASMAuth.Client
{
    public class LoginUser
    {
        public string DisplayName { get; set; }
        public string Jwt { get; set; }
        public ClaimsPrincipal ClaimsPrincipal { get; set; }
        public LoginUser(string nom, string jwt, ClaimsPrincipal principal)
        {
            DisplayName = nom;
            Jwt = jwt;
            ClaimsPrincipal = principal;
        }
    }
}
