using BlazorWASMAuth.Server.DataModels;

namespace BlazorWASMAuth.Server.Services
{
    public class UserService
    {
        public User LoginUser(string login, string password)
        {
            //Check mot de passe

            return new User()
            {
                Email = login,
                Id = 1,
                UserName = "admin",
                SecurityStamp = login + 1 + "admin"
            };
        }

        internal void AddUser(User user)
        {
            //ajout en base
        }

    }
}
