using InAndOut.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models.ViewModels
{
    public class BrowseMoviesDetialsViewModel
    {

        public List<TblGenre> Generes { get; set; }
        public List<TblLanguage> Laguages { get; set; }
        public List<TblFilm> Films { get; set; }


    }
}
