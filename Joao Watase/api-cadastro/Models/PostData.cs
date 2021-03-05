using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_cadastro.Models
{
    public class PostData
    {
        public PostData(string name, int age, string surname = null)
        {
            Name = name;
            Age = age;
            Surname = surname;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Surname { get; set; }
    }
}