using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PostgreSQL.ModelsGenerated
{
    public partial class PotgreContext : DbContext
    {
        public PotgreContext()
        {
        }

        public PotgreContext(DbContextOptions<PotgreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Userdetails> Userdetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=SearchEngine;User Id=postgres;Password=Volvo2005;Port=5432");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Userdetails>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("userdetails_pkey");

                entity.ToTable("userdetails");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(25);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(25);

                entity.Property(e => e.Confirmpassword)
                    .HasColumnName("confirmpassword")
                    .HasMaxLength(8);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(25);

                entity.Property(e => e.CreatedOn).HasColumnName("created_on");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.LastLogin).HasColumnName("last_login");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(8);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(15);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(25);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
