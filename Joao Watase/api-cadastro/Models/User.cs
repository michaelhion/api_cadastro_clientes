using System;

namespace api_cadastro.Models
{
    public class User
    {
        public User(string firstName, int age, string surname = null)
        {

            Id = Guid.NewGuid().ToString();
            FirstName = firstName;
            Surname = surname;
            Age = age;
            CreationDate = DateTime.Now;
        }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set;  }
        public int Age { get; set;  }
        public DateTime CreationDate { get; set; }
    }
}