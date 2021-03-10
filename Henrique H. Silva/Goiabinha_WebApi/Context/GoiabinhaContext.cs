using Goiabinha_WebApi.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goiabinha_WebApi.Context
{
    public class GoiabinhaContext : DbContext
    {
        public GoiabinhaContext()
        {
            InitialCreate initialCreate = new InitialCreate();
        }
        public GoiabinhaContext(DbContextOptions<GoiabinhaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //String de conexão para fazer teste unitario, necessário criar um banco de dados sql server para executar os testes 
                //optionsBuilder.UseSqlServer("Server=localhost, 1433;Database=DbUsuarios;User=sa;Password=12as$goia!;");

                //String do docker-composer
                optionsBuilder.UseSqlServer("Server=db;Database=DbUsuarios;User=sa;Password=Goiabeira007;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.id).HasColumnName("id");

            });
        }
    }
}
