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
            this.name = name;
            this.age = age;
            this.surname = surname;
        }

        public string name { get; set; }
        public int age { get; set; }
        public string surname { get; set; }
    }
}
