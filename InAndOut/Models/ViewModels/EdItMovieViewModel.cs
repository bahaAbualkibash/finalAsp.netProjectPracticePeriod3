using InAndOut.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models.ViewModels
{
    public class EditMovieViewModel
    {
        public int FilmId { get; set; }
        public string FilmName { get; set; }
        public DateTime FilmReleaseDate { get; set; }
        public string FilmSynopsis { get; set; }
        public int FilmRunTimeMinutes { get; set; }
        public decimal FilmPrice { get; set; }
        public string FilmImage { get; set; }
        public List<TblGenreMovies> Genres { get; set; }
        public List<TblLanguagesMovies> Languages { get; set; }
        public List<TblActorsMovie> Actors { get; set; }



    }
}
