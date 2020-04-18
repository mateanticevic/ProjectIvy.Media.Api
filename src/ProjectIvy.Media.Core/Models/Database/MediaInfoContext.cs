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

        public virtual DbSet<Akas> Akas { get; set; }
        public virtual DbSet<Crew> Crew { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Name> Name { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Title> Title { get; set; }
        public virtual DbSet<TitleGenre> TitleGenre { get; set; }
        public virtual DbSet<TitleName> TitleName { get; set; }
        public virtual DbSet<TitleType> TitleType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=db.anticevic.net;Database=MediaInfo;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Akas>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("akas");

                entity.Property(e => e.Attributes)
                    .IsRequired()
                    .HasColumnName("attributes");

                entity.Property(e => e.IsOriginalTitle)
                    .HasColumnName("isOriginalTitle")
                    .HasMaxLength(10);

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasColumnName("language")
                    .HasMaxLength(50);

                entity.Property(e => e.Ordering).HasColumnName("ordering");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasColumnName("region")
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");

                entity.Property(e => e.TitleId)
                    .IsRequired()
                    .HasColumnName("titleId")
                    .HasMaxLength(10);

                entity.Property(e => e.Types)
                    .IsRequired()
                    .HasColumnName("types");
            });

            modelBuilder.Entity<Crew>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("crew");

                entity.Property(e => e.Directors).HasColumnName("directors");

                entity.Property(e => e.Tconst)
                    .IsRequired()
                    .HasColumnName("tconst")
                    .HasMaxLength(10);

                entity.Property(e => e.Writers).HasColumnName("writers");
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

                entity.Property(e => e.Genres).HasMaxLength(250);

                entity.Property(e => e.ValueId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TitleGenre>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TitleGenre", "Imdb");

                entity.HasOne(d => d.Genre)
                    .WithMany()
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TitleGenre_Genre");

                entity.HasOne(d => d.Title)
                    .WithMany()
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TitleGenre_Title");
            });

            modelBuilder.Entity<TitleName>(entity =>
            {
                entity.HasKey(e => new { e.TitleId, e.NameId });

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
                    .WithMany(p => p.TitleNames)
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
