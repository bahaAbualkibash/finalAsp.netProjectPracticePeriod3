using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Database
{
    public class TblLanguagesMovies
    {
        [Key]
        [Column("LanguageFilmID")]
        public int LanguageFilmId { get; set; }

        [Column("FilmID")]
        public int FilmId { get; set; }
        [Column("LanguageID")]
        public int LanguageId { get; set; }

        [ForeignKey(nameof(LanguageId))]
        public virtual TblLanguage Language { get; set; }
        [ForeignKey(nameof(FilmId))]
        public virtual TblFilm Film { get; set; }
    }
}
