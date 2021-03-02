using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Api_intelitrader.Domains;
using System.Security.Cryptography;
using System.Text;

#nullable disable

namespace Api_intelitrader.Contexts
{
    public partial class EntidadeContext : DbContext
    {
        public EntidadeContext()
        {
        }

        public EntidadeContext(DbContextOptions<EntidadeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entidade> Entidades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-AMSIKG3\\SQLEXPRESS; Initial Catalog=api_intelitrader;user=sa;password=Pa55word2019");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Entidade>(entity =>
            {
                entity.ToTable("Entidade");


                entity.HasKey(e => e.Id);

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasColumnName("creationDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName)
                    .IsRequired(true)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.SurName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("surName")
                    .IsRequired(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
