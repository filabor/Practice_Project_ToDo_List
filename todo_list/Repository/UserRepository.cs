using todo_list.Models;

namespace todo_list.Repository
{
    public class UserRepository
    {
        private static User user;

        public UserRepository()
        {
            if(user == null)
            {
                user = new User();
                UserData();
            }
        }

        public User GetUser()
        {
            return user;
        }

        public void UserData()
        {
            user = new User()
            {
                UserID = 259,
                UserName = "Marko Marić",
                Email = "markomarić@mail.com",
                Phone = "095/555635"
            };
           
        }

    }
}
