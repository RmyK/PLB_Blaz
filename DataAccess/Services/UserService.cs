using DataAccess.DataModels;
using DataAccess.Services.DataAcces;

namespace DataAccess.Services
{
    public class UserService
    {
        private User currentUser;
        private readonly Repository repo;

        public User GetCurrentUser => currentUser;

        public UserService(Repository repository)
        {
            repo = repository;
        }

        public void AddUser(User usr)
        {
            repo.Insert(usr);
            currentUser = usr;
        }

        public void SetUser(string name, string prenom)
        {
            var usr = repo.Where<User>(t => t.Nom == name && t.Prenom == prenom);
            if (usr.Count() == 1)
            {
                currentUser = usr.SingleOrDefault();
                //return true;
            }
            else
            {
                //return false;
                throw new Exception("Impossible de retrouver l'utilisateur");
            }
        }
    }
}
