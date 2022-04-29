using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MvccoreStyle.Models.Data
{
    public partial class DBPerCoreContext : DbContext
    {
        public DBPerCoreContext()
        {
        }

        public DBPerCoreContext(DbContextOptions<DBPerCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Personel> Personels { get; set; } = null!;
        public virtual DbSet<Sehir> Sehirs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-G2472IUH\\SQLEXPRESS;Database=DBPerCore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Personel>(entity =>
            {
                entity.ToTable("Personel");

                entity.HasIndex(e => e.SehirId, "IX_Personel_SehirId");

                entity.HasOne(d => d.Sehir)
                    .WithMany(p => p.Personels)
                    .HasForeignKey(d => d.SehirId);
            });

            modelBuilder.Entity<Sehir>(entity =>
            {
                entity.ToTable("Sehir");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
