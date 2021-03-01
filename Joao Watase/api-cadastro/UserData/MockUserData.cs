using api_cadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_cadastro.UserData
{
    public class MockUserData : IUserData
    {
        private List<User> users = new List<User>()
        {
            new User("joao",17,"watase"),
            new User("nome",3,"sobrenome")
        };

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void DeleteUser(User user)
        {
            users.Remove(user);
        }

        public User GetUser(string id)
        {
            return users.SingleOrDefault(x => x.Id == id);
        }

        public List<User> GetUsers()
        {
            return users;
        }
    }
}
