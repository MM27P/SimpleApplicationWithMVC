using SimpleApplicationWithMVC.Database;
using SimpleApplicationWithMVC.Database.Model;
using SimpleApplicationWithMVC.Services.DTO;
using SimpleApplicationWithMVC.Services.Interfaces;
using System.Linq;

namespace SimpleApplicationWithMVC.Services.Services
{
    public class UserServices : IUserServices
    {
        public UserServices(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        private DatabaseContext databaseContext;
        private User CurrentUser;

        public void AddUser(string login, string password)
        {
            databaseContext.Users.Add(new User() { Login = login, Password = password });
        }

        public int AuthorizateUser(UserDTO userDTO)
        {
            var user = databaseContext.Users.Where(x => x.Login.Equals(userDTO.Login)).FirstOrDefault();

            if (user != null && user.Password.Equals(userDTO.Password))
            {
                CurrentUser = user;
                return user.Id;
            }
            else
            {
                return -1;
            }
        }

        public User GetCurrentUser()
        {
            return CurrentUser;
        }
    }
}
