using System;
using Microsoft.EntityFrameworkCore;

namespace ProjectIvy.Media.Core.Models.Database
{
    public partial class MediaInfoContext : DbContext
    {
        public MediaInfoContext()
        {
        }

        public MediaInfoContext(DbContextOptions<MediaInfoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aka> Aka { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Name> Name { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Title> Title { get; set; }
        public virtual DbSet<TitleGenre> TitleGenre { get; set; }
        public virtual DbSet<TitleName> TitleName { get; set; }
        public virtual DbSet<TitleType> TitleType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING_MEDIA"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aka>(entity =>
            {
                entity.ToTable("Aka", "Imdb");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.TitleNavigation)
                    .WithMany(p => p.Aka)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Aka_Title");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre", "Imdb");

                entity.HasIndex(e => e.ValueId)
                    .HasName("IX_Genre")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ValueId)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Language", "Imdb");

                entity.HasIndex(e => e.ValueId)
                    .HasName("IX_Language")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ValueId)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<Name>(entity =>
            {
                entity.ToTable("Name", "Imdb");

                entity.HasIndex(e => e.ValueId)
                    .HasName("IX_Name")
                    .IsUnique();

                entity.Property(e => e.ValueId)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region", "Imdb");

                entity.HasIndex(e => e.ValueId)
                    .HasName("IX_Region")
                    .IsUnique();

                entity.Property(e => e.ValueId)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role", "Imdb");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ValueId)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.ToTable("Title", "Imdb");

                entity.HasIndex(e => e.ValueId)
                    .HasName("IX_Title")
                    .IsUnique();

                entity.Property(e => e.AverageRating).HasColumnType("numeric(3, 1)");

                entity.Property(e => e.ValueId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.ParentTitle)
                    .WithMany(p => p.InverseParentTitle)
                    .HasForeignKey(d => d.ParentTitleId)
                    .HasConstraintName("FK_Title_Title_ParentTitle");
            });

            modelBuilder.Entity<TitleGenre>(entity =>
            {
                entity.HasKey(e => new { e.TitleId, e.GenreId });

                entity.ToTable("TitleGenre", "Imdb");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.TitleGenre)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TitleGenre_Genre");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.TitleGenre)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TitleGenre_Title");
            });

            modelBuilder.Entity<TitleName>(entity =>
            {
                entity.HasKey(e => new { e.TitleId, e.NameId, e.Ordering });

                entity.ToTable("TitleName", "Imdb");

                entity.HasOne(d => d.Name)
                    .WithMany(p => p.TitleName)
                    .HasForeignKey(d => d.NameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TitleName_Name");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TitleName)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TitleName_Role");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.TitleName)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TitleName_Title");
            });

            modelBuilder.Entity<TitleType>(entity =>
            {
                entity.ToTable("TitleType", "Imdb");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ValueId)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
