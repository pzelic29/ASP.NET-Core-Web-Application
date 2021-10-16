using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Petra_Zelić___PMA.DbModels
{
    public partial class MOVIEContext : DbContext
    {
        public MOVIEContext()
        {
        }

        public MOVIEContext(DbContextOptions<MOVIEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Redatelj> Redateljs { get; set; }
        public virtual DbSet<Zanr> Zanrs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= DESKTOP-M8NOBUT\\SQLEXPRESS;Database=MOVIE;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Croatian_CI_AS");

            modelBuilder.Entity<Film>(entity =>
            {
                entity.ToTable("FILM");

                entity.Property(e => e.FilmId).HasColumnName("Film_ID");

                entity.Property(e => e.Cijena).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RedateljId).HasColumnName("Redatelj_ID");

                entity.Property(e => e.Slika).HasMaxLength(1000);

                entity.Property(e => e.ZanrId).HasColumnName("Zanr_ID");

                entity.HasOne(d => d.Redatelj)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.RedateljId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FILM_REDATELJ");

                entity.HasOne(d => d.Zanr)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.ZanrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FILM_ZANR");
            });

            modelBuilder.Entity<Redatelj>(entity =>
            {
                entity.ToTable("REDATELJ");

                entity.Property(e => e.RedateljId).HasColumnName("Redatelj_ID");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Zanr>(entity =>
            {
                entity.ToTable("ZANR");

                entity.Property(e => e.ZanrId).HasColumnName("Zanr_ID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
