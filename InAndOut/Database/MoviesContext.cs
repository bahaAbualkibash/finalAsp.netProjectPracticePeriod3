using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using InAndOut.Models.ViewModels;

#nullable disable

namespace InAndOut.Database
{
    public partial class MoviesContext : IdentityDbContext
    {
        public MoviesContext()
        {
        }

        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblActor> TblActors { get; set; }
        public virtual DbSet<TblActorsMovie> TblActorsMovies { get; set; }
        public virtual DbSet<TblCast> TblCasts { get; set; }
        public virtual DbSet<TblCertificate> TblCertificates { get; set; }
        public virtual DbSet<TblCountry> TblCountries { get; set; }
        public virtual DbSet<TblDirector> TblDirectors { get; set; }
        public virtual DbSet<TblFilm> TblFilms { get; set; }
        public virtual DbSet<TblGenre> TblGenres { get; set; }
        public virtual DbSet<TblLanguage> TblLanguages { get; set; }
        public virtual DbSet<TblStudio> TblStudios { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }
        public virtual DbSet<VwFilm> VwFilms { get; set; }
        public virtual DbSet<VwFilmDetail> VwFilmDetails { get; set; }
        public virtual DbSet<VwFilmSimple> VwFilmSimples { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Movies;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<TblActor>(entity =>
            {
                entity.Property(e => e.ActorId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblActorsMovie>(entity =>
            {
                entity.HasOne(d => d.Actor)
                    .WithMany()
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK_Tbl_Actors_Movies_tblActor");

                entity.HasOne(d => d.Film)
                    .WithMany()
                    .HasForeignKey(d => d.FilmId)
                    .HasConstraintName("FK_Tbl_Actors_Movies_tblFilm");
            });
            modelBuilder.Entity<TblGenreMovies>(entity =>
            {
                entity.HasOne(d => d.Genre)
                    .WithMany()
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK_Tbl_Genres_Movies_tblGenre");

                entity.HasOne(d => d.Film)
                    .WithMany()
                    .HasForeignKey(d => d.FilmId)
                    .HasConstraintName("FK_Tbl_Genres_Movies_tblFilm");
            });
            modelBuilder.Entity<TblLanguagesMovies>(entity =>
            {
                entity.HasOne(d => d.Language)
                    .WithMany()
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_Tbl_Languages_Movies_tblLanguage");

                entity.HasOne(d => d.Film)
                    .WithMany()
                    .HasForeignKey(d => d.FilmId)
                    .HasConstraintName("FK_Tbl_Languages_Movies_tblFilm");
            });

            modelBuilder.Entity<TblCast>(entity =>
            {
                entity.Property(e => e.CastId).ValueGeneratedNever();

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.TblCasts)
                    .HasForeignKey(d => d.FilmId)
                    .HasConstraintName("FK_tblCast_tblFilm");
            });

            modelBuilder.Entity<TblCertificate>(entity =>
            {
                entity.Property(e => e.CertificateId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblCountry>(entity =>
            {
                entity.Property(e => e.CountryId).ValueGeneratedNever();

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.TblCountries)
                    .HasForeignKey(d => d.FilmId)
                    .HasConstraintName("FK_tblCountry_tblFilm");
            });

            modelBuilder.Entity<TblDirector>(entity =>
            {
                entity.Property(e => e.DirectorId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblFilm>(entity =>
            {
                entity.Property(e => e.FilmId).ValueGeneratedNever();

                entity.HasOne(d => d.FilmActor)
                    .WithMany(p => p.TblFilms)
                    .HasForeignKey(d => d.FilmActorId)
                    .HasConstraintName("FK_tblFilm_tblActor");

                entity.HasOne(d => d.FilmDirector)
                    .WithMany(p => p.TblFilms)
                    .HasForeignKey(d => d.FilmDirectorId)
                    .HasConstraintName("FK_tblFilm_tblDirector");
            });

            modelBuilder.Entity<TblGenre>(entity =>
            {
                entity.Property(e => e.GenreId).ValueGeneratedNever();

                entity.Property(e => e.GenreName).IsUnicode(false);

     
            });

            modelBuilder.Entity<TblLanguage>(entity =>
            {
                entity.Property(e => e.LanguageId).ValueGeneratedNever();
                entity.Property(e => e.Language).IsUnicode(false);

              
            });

            modelBuilder.Entity<TblStudio>(entity =>
            {
                entity.Property(e => e.StudioId).ValueGeneratedNever();

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.TblStudios)
                    .HasForeignKey(d => d.FilmId)
                    .HasConstraintName("FK_tblStudio_tblFilm");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasOne(d => d.Film)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.FilmId)
                    .HasConstraintName("FK_TblUser_tblFilm");
            });

            modelBuilder.Entity<VwFilm>(entity =>
            {
                entity.ToView("vwFilms");
            });

            modelBuilder.Entity<VwFilmDetail>(entity =>
            {
                entity.ToView("vwFilmDetails");
            });

            modelBuilder.Entity<VwFilmSimple>(entity =>
            {
                entity.ToView("vwFilmSimple");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
