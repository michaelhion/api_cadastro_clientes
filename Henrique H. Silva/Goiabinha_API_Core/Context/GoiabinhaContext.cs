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
                optionsBuilder.UseSqlServer("Server=localhost, 1433;Database=DbUsuarios;User=sa;Password=12as$goia!;");
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
