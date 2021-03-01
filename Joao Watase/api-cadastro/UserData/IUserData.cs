using api_cadastro.Models;
using System.Collections.Generic;

namespace api_cadastro.UserData
{
    public interface IUserData
    {
        List<User> GetUsers();
        User GetUser(string id);
        void AddUser(User user);
        void DeleteUser(User user);
    }
}
