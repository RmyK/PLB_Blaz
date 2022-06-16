using DataAccess.DataModels;

namespace DataAccess.Services.MsgService
{
    public class UserChanged : Signal
    {
        public User NewUser { get; set; }

        public UserChanged(User user)
        {
            NewUser = user;
        }
    }
}
