using Goiabinha_API_Core.Migrations;
using Goiabinha_API_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goiabinha_API_Core.Context
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
