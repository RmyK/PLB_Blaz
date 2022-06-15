using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWASMAuth.Shared
{
    public class LoginResponse
    {
        private bool IsLoggedIn { get; set; }

        public string Token { get; set; }
        public LoginResponse()
        {

        }

        public LoginResponse(bool logIn, string jwtToken)
        {
            IsLoggedIn = logIn;
            Token = jwtToken;
        }

        public static LoginResponse Failed => new LoginResponse(false, string.Empty);
    }
}
