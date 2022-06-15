using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlazorWASMAuth.Client.Authentication
{
    public class JwtAuthenticationStateProvider : AuthenticationStateProvider
    {
        private static AuthenticationState NotAuthenticatedState = new AuthenticationState(new System.Security.Claims.ClaimsPrincipal());
        private LoginUser _user;

        public string DisplayName => this._user?.DisplayName;
        public bool IsLoggedIn => this._user != null;
        public string Token => this._user?.Jwt;

        public void Login(string jwt)
        {
            var principal = Deserialize(jwt);
            this._user = new LoginUser(principal.Identity.Name, jwt, principal);
            this.NotifyAuthenticationStateChanged(Task.FromResult(GetState()));
        }

        public void Logout()
        {
            this._user = null;
            this.NotifyAuthenticationStateChanged(Task.FromResult(GetState()));
        }

        private AuthenticationState GetState()
        {
            if (_user != null)
                return new AuthenticationState(_user.ClaimsPrincipal);
            else
                return NotAuthenticatedState;
        }

        private ClaimsPrincipal Deserialize(string jwt)
        {
            var jsonToken = new JwtSecurityTokenHandler().ReadToken(jwt);
            var token = jsonToken as JwtSecurityToken;

            var claimIdentity = new ClaimsIdentity(token.Claims, "jwt");
            var principal = new ClaimsPrincipal(claimIdentity);

            return principal;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(GetState());
        }
    }
}
