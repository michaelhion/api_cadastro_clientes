using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_cadastro_cliente.Context
{
    public class ClienteContexto : DbContext
    {
        public ClienteContexto() { }

        public ClienteContexto(DbContextOptions<ClienteContexto> options)
            : base(options)
        {
        }

        public virtual DbSet<ClienteModel> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteModel>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");

            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseSqlServer("Server=NOTE\\SQLEXPRESS;Database=Intelitrader;User=sa;Password=senha;");
                //optionsBuilder.UseSqlServer("Server=michaelhion_db_1;Database=Intelitrader;User=sa;Password=bQ7gE5tL@@xm9WTa;");
                optionsBuilder.UseSqlServer("Server=db;Database=Intelitrader;userid=sa;Password=bQ7gE5tL@@xm9WTa");
            }
        }
    }
}
