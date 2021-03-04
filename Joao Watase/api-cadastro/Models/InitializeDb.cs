using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_cadastro.Models
{
    public class InitializeDb
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Users.Any())
            {
                return;
            }
            var usuarios = new User[]
            {
              new User("joao", 17, "watase"),
              new User("nome", 3, "sobrenome")
            };
            foreach (User p in usuarios)
            {
                context.Users.Add(p);
            }
            context.SaveChanges();
        }
    }
}
