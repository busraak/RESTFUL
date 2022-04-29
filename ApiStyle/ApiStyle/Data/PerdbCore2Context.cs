using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiStyle.Data
{
    public partial class PerdbCore2Context : DbContext
    {
        public PerdbCore2Context()
        {
        }

        public PerdbCore2Context(DbContextOptions<PerdbCore2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Personel> Personels { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-9C0OMUVA;Database=PerdbCore2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");
            });

            modelBuilder.Entity<Personel>(entity =>
            {
                entity.ToTable("Personel");

                entity.HasIndex(e => e.CityId, "IX_Personel_CityId");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Personels)
                    .HasForeignKey(d => d.CityId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
