﻿// <auto-generated />
using System;
using InAndOut.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InAndOut.Migrations
{
    [DbContext(typeof(MoviesContext))]
    [Migration("20210831062047_addJuntionTableGenreFilm")]
    partial class addJuntionTableGenreFilm
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Arabic_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InAndOut.Database.TblActor", b =>
                {
                    b.Property<int>("ActorId")
                        .HasColumnType("int")
                        .HasColumnName("ActorID");

                    b.Property<DateTime?>("ActorDob")
                        .HasColumnType("datetime")
                        .HasColumnName("ActorDOB");

                    b.Property<string>("ActorGender")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ActorName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ActorId");

                    b.ToTable("tblActor");
                });

            modelBuilder.Entity("InAndOut.Database.TblActorsMovie", b =>
                {
                    b.Property<int>("ActorFilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ActorFilmID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActorId")
                        .HasColumnType("int")
                        .HasColumnName("ActorID");

                    b.Property<int?>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("FilmID");

                    b.HasKey("ActorFilmId");

                    b.HasIndex("ActorId");

                    b.HasIndex("FilmId");

                    b.ToTable("Tbl_Actors_Movies");
                });

            modelBuilder.Entity("InAndOut.Database.TblCast", b =>
                {
                    b.Property<int>("CastId")
                        .HasColumnType("int")
                        .HasColumnName("CastID");

                    b.Property<int?>("CastActorId")
                        .HasColumnType("int")
                        .HasColumnName("CastActorID");

                    b.Property<string>("CastCharacterName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("CastFilmId")
                        .HasColumnType("int")
                        .HasColumnName("CastFilmID");

                    b.Property<int?>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("FilmID");

                    b.HasKey("CastId");

                    b.HasIndex("FilmId");

                    b.ToTable("tblCast");
                });

            modelBuilder.Entity("InAndOut.Database.TblCertificate", b =>
                {
                    b.Property<long>("CertificateId")
                        .HasColumnType("bigint")
                        .HasColumnName("CertificateID");

                    b.Property<string>("Certificate")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CertificateId");

                    b.ToTable("tblCertificate");
                });

            modelBuilder.Entity("InAndOut.Database.TblCountry", b =>
                {
                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("CountryID");

                    b.Property<string>("CountryName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("FilmID");

                    b.HasKey("CountryId");

                    b.HasIndex("FilmId");

                    b.ToTable("tblCountry");
                });

            modelBuilder.Entity("InAndOut.Database.TblDirector", b =>
                {
                    b.Property<int>("DirectorId")
                        .HasColumnType("int")
                        .HasColumnName("DirectorID");

                    b.Property<DateTime?>("DirectorDob")
                        .HasColumnType("datetime")
                        .HasColumnName("DirectorDOB");

                    b.Property<string>("DirectorGender")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DirectorName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("DirectorId");

                    b.ToTable("tblDirector");
                });

            modelBuilder.Entity("InAndOut.Database.TblFilm", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("FilmID");

                    b.Property<int?>("FilmActorId")
                        .HasColumnType("int")
                        .HasColumnName("FilmActorID");

                    b.Property<int?>("FilmBoxOfficeDollars")
                        .HasColumnType("int");

                    b.Property<int?>("FilmBudgetDollars")
                        .HasColumnType("int");

                    b.Property<int?>("FilmCastId")
                        .HasColumnType("int")
                        .HasColumnName("FilmCastID");

                    b.Property<long?>("FilmCertificateId")
                        .HasColumnType("bigint")
                        .HasColumnName("FilmCertificateID");

                    b.Property<int?>("FilmCountryId")
                        .HasColumnType("int")
                        .HasColumnName("FilmCountryID");

                    b.Property<int?>("FilmDirectorId")
                        .HasColumnType("int")
                        .HasColumnName("FilmDirectorID");

                    b.Property<int?>("FilmGenreId")
                        .HasColumnType("int")
                        .HasColumnName("FilmGenreID");

                    b.Property<string>("FilmImage")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FilmImage");

                    b.Property<int?>("FilmLanguageId")
                        .HasColumnType("int")
                        .HasColumnName("FilmLanguageID");

                    b.Property<string>("FilmName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("FilmOscarNominations")
                        .HasColumnType("int");

                    b.Property<int?>("FilmOscarWins")
                        .HasColumnType("int");

                    b.Property<decimal>("FilmPrice")
                        .HasColumnType("money");

                    b.Property<DateTime?>("FilmReleaseDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("FilmRunTimeMinutes")
                        .HasColumnType("int");

                    b.Property<int?>("FilmStudioId")
                        .HasColumnType("int")
                        .HasColumnName("FilmStudioID");

                    b.Property<string>("FilmSynopsis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilmTrailer")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FilmTrailer");

                    b.HasKey("FilmId");

                    b.HasIndex("FilmActorId");

                    b.HasIndex("FilmDirectorId");

                    b.ToTable("tblFilm");
                });

            modelBuilder.Entity("InAndOut.Database.TblGenre", b =>
                {
                    b.Property<long>("GenreId")
                        .HasColumnType("bigint");

                    b.Property<string>("GenreName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("GenreId");

                    b.ToTable("tblGenre");
                });

            modelBuilder.Entity("InAndOut.Database.TblLanguage", b =>
                {
                    b.Property<int>("LanguageId")
                        .HasColumnType("int")
                        .HasColumnName("LanguageID");

                    b.Property<int?>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("FilmID");

                    b.Property<string>("Language")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("LanguageId");

                    b.HasIndex("FilmId");

                    b.ToTable("tblLanguage");
                });

            modelBuilder.Entity("InAndOut.Database.TblStudio", b =>
                {
                    b.Property<int>("StudioId")
                        .HasColumnType("int")
                        .HasColumnName("StudioID");

                    b.Property<int?>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("FilmID");

                    b.Property<string>("StudioName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("StudioId");

                    b.HasIndex("FilmId");

                    b.ToTable("tblStudio");
                });

            modelBuilder.Entity("InAndOut.Database.TblUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("FilmID");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("password");

                    b.Property<byte[]>("UserImage")
                        .HasColumnType("image")
                        .HasColumnName("userImage");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("username");

                    b.HasKey("UserId");

                    b.HasIndex("FilmId");

                    b.ToTable("TblUser");
                });

            modelBuilder.Entity("InAndOut.Database.VwFilm", b =>
                {
                    b.Property<string>("Certificate")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CountryName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DirectorName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FilmName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Language")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("StudioName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.ToView("vwFilms");
                });

            modelBuilder.Entity("InAndOut.Database.VwFilmDetail", b =>
                {
                    b.Property<string>("Certificate")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.ToView("vwFilmDetails");
                });

            modelBuilder.Entity("InAndOut.Database.VwFilmSimple", b =>
                {
                    b.Property<int?>("FilmBoxOfficeDollars")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("FilmID");

                    b.Property<string>("FilmName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.ToView("vwFilmSimple");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("InAndOut.Database.TblActorsMovie", b =>
                {
                    b.HasOne("InAndOut.Database.TblActor", "Actor")
                        .WithMany()
                        .HasForeignKey("ActorId")
                        .HasConstraintName("FK_Tbl_Actors_Movies_tblActor");

                    b.HasOne("InAndOut.Database.TblFilm", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .HasConstraintName("FK_Tbl_Actors_Movies_tblFilm");

                    b.Navigation("Actor");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("InAndOut.Database.TblCast", b =>
                {
                    b.HasOne("InAndOut.Database.TblFilm", "Film")
                        .WithMany("TblCasts")
                        .HasForeignKey("FilmId")
                        .HasConstraintName("FK_tblCast_tblFilm");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("InAndOut.Database.TblCountry", b =>
                {
                    b.HasOne("InAndOut.Database.TblFilm", "Film")
                        .WithMany("TblCountries")
                        .HasForeignKey("FilmId")
                        .HasConstraintName("FK_tblCountry_tblFilm");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("InAndOut.Database.TblFilm", b =>
                {
                    b.HasOne("InAndOut.Database.TblActor", "FilmActor")
                        .WithMany("TblFilms")
                        .HasForeignKey("FilmActorId")
                        .HasConstraintName("FK_tblFilm_tblActor");

                    b.HasOne("InAndOut.Database.TblDirector", "FilmDirector")
                        .WithMany("TblFilms")
                        .HasForeignKey("FilmDirectorId")
                        .HasConstraintName("FK_tblFilm_tblDirector");

                    b.Navigation("FilmActor");

                    b.Navigation("FilmDirector");
                });

            modelBuilder.Entity("InAndOut.Database.TblLanguage", b =>
                {
                    b.HasOne("InAndOut.Database.TblFilm", "Film")
                        .WithMany("TblLanguages")
                        .HasForeignKey("FilmId")
                        .HasConstraintName("FK_tblLanguage_tblFilm");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("InAndOut.Database.TblStudio", b =>
                {
                    b.HasOne("InAndOut.Database.TblFilm", "Film")
                        .WithMany("TblStudios")
                        .HasForeignKey("FilmId")
                        .HasConstraintName("FK_tblStudio_tblFilm");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("InAndOut.Database.TblUser", b =>
                {
                    b.HasOne("InAndOut.Database.TblFilm", "Film")
                        .WithMany("TblUsers")
                        .HasForeignKey("FilmId")
                        .HasConstraintName("FK_TblUser_tblFilm");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InAndOut.Database.TblActor", b =>
                {
                    b.Navigation("TblFilms");
                });

            modelBuilder.Entity("InAndOut.Database.TblDirector", b =>
                {
                    b.Navigation("TblFilms");
                });

            modelBuilder.Entity("InAndOut.Database.TblFilm", b =>
                {
                    b.Navigation("TblCasts");

                    b.Navigation("TblCountries");

                    b.Navigation("TblLanguages");

                    b.Navigation("TblStudios");

                    b.Navigation("TblUsers");
                });
#pragma warning restore 612, 618
        }
    }
}