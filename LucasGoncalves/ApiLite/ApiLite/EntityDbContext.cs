using ApiLite.Models;
using Microsoft.EntityFrameworkCore;

namespace IntelitraderAPI
{
    public class EntityDbContext : DbContext
    {

        public EntityDbContext(DbContextOptions<EntityDbContext> options) : base(options)
        {

        }

        public DbSet<Entidade> Entidades { get; set; }

        //Faz a conexao com o banco
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ////Rodar a api
            //optionsBuilder
            //    .UseSqlServer(
            //        @"Server=DESKTOP-AMSIKG3\SQLEXPRESS;Database=DbTest;User=sa;Password=Pa55word2019*",
            //        providerOptions => { providerOptions.EnableRetryOnFailure(); });

            //Criar o container no docker
            optionsBuilder
                .UseSqlServer(
                    @"Server=db;Database=DbTest;User=sa;Password=Pa55word2019*",
                    providerOptions => { providerOptions.EnableRetryOnFailure(); });
        }




    }
}
