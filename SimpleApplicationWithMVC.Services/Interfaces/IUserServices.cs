using SimpleApplicationWithMVC.Database.Model;
using SimpleApplicationWithMVC.Services.DTO;

namespace SimpleApplicationWithMVC.Services.Interfaces
{
    public interface IUserServices
    {
        int AuthorizateUser(UserDTO user);
        User GetCurrentUser();
        void AddUser(string login, string password);
    }
}
