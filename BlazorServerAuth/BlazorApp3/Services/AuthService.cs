using System.Security.Claims;

namespace BlazorApp3.Services
{
    public class AuthService
    {
        public AuthService()
        {
            Users = new Dictionary<string, ClaimsPrincipal>();
        }
        public Dictionary<string,ClaimsPrincipal> Users { get; set; }
    }
}
