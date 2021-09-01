using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Database
{
    public class TblGenreMovies
    {
        [Key]
        [Column("ActorFilmID")]
        public int GenreFilmId { get; set; }

        [Column("FilmID")]
        public int FilmId { get; set; }
        [Column("GenreID")]
        public long GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public virtual TblGenre Genre { get; set; }
        [ForeignKey(nameof(FilmId))]
        public virtual TblFilm Film { get; set; }
    }
}
