using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InAndOut.Database
{
    [Table("tblFilm")]
    public partial class TblFilm
    {
        public TblFilm()
        {
            TblCasts = new HashSet<TblCast>();
            TblCountries = new HashSet<TblCountry>();
            //TblGenres = new HashSet<TblGenre>();
            //TblLanguages = new HashSet<TblLanguage>();
            TblStudios = new HashSet<TblStudio>();
            TblUsers = new HashSet<TblUser>();
        }

        [Key]
        [Column("FilmID")]
        public int FilmId { get; set; }
        [Required]
        [StringLength(255)]
        public string FilmName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FilmReleaseDate { get; set; }
        [Column("FilmDirectorID")]
        public int? FilmDirectorId { get; set; }
        [Column("FilmLanguageID")]
        public int? FilmLanguageId { get; set; }
        [Column("FilmCountryID")]
        public int? FilmCountryId { get; set; }
        [Column("FilmStudioID")]
        public int? FilmStudioId { get; set; }
        public string FilmSynopsis { get; set; }
        public int? FilmRunTimeMinutes { get; set; }
        [Column("FilmCertificateID")]
        public long? FilmCertificateId { get; set; }
        public int? FilmBudgetDollars { get; set; }
        public int? FilmBoxOfficeDollars { get; set; }
        public int? FilmOscarNominations { get; set; }
        public int? FilmOscarWins { get; set; }
        [Column("FilmGenreID")]
        public int? FilmGenreId { get; set; }
        [Column(TypeName = "money")]
        public decimal FilmPrice { get; set; }
        [Column("FilmActorID")]
        public int? FilmActorId { get; set; }
        [Column("FilmCastID")]
        public int? FilmCastId { get; set; }
        [Column("FilmImage")]
        public string FilmImage { get; set;}

        [Column("FilmTrailer")]
        public string FilmTrailer { get; set; }

        [ForeignKey(nameof(FilmActorId))]
        [InverseProperty(nameof(TblActor.TblFilms))]
        public virtual TblActor FilmActor { get; set; }
        [ForeignKey(nameof(FilmDirectorId))]
        [InverseProperty(nameof(TblDirector.TblFilms))]
        public virtual TblDirector FilmDirector { get; set; }
        [InverseProperty(nameof(TblCast.Film))]
        public virtual ICollection<TblCast> TblCasts { get; set; }
        [InverseProperty(nameof(TblCountry.Film))]
        public virtual ICollection<TblCountry> TblCountries { get; set; }
        [InverseProperty(nameof(TblStudio.Film))]
        public virtual ICollection<TblStudio> TblStudios { get; set; }
        [InverseProperty(nameof(TblUser.Film))]
        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
