using ToDoListBlazor.DataModels;

namespace ToDoListBlazor.Services
{
    public class UserService
    {
        private User currentUser;
        private List<User> Users = new List<User>();

        public User GetCurrentUser => currentUser;

        public void AddUser(User usr)
        {
            if (!Users.Select(u => u.GetHashCode()).Contains(usr.GetHashCode()))
                Users.Add(usr);

            currentUser = usr;
        }
    }
}
