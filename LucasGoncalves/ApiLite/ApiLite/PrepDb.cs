using ApiLite.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace IntelitraderAPI
{
    public class PrepDb
    {
        public static void PropPopulation(IApplicationBuilder app)
        {
            //Cria o escopo do banco
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<EntityDbContext>());
            }
        }

        public static void SeedData(EntityDbContext context)
        {
            System.Console.WriteLine("Appling Migrations...");

            context.Database.Migrate();

            if (!context.Entidades.Any())
            {
                //Adiciona uma tabela ao banco criado
                System.Console.WriteLine("Adicionando data - seeding...");
                context.Entidades.AddRange(
                    new Entidade() { FirstName = "Nome", SurName = "Sobrenome", Age = 25, CreationDate = DateTime.Now }
                );


                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("A populção do banco ja foi feita - not seeding");
            }

        }
    }
}
