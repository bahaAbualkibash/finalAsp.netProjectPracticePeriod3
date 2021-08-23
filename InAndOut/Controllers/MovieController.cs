using InAndOut.Database;
using InAndOut.Models.Repository;
using InAndOut.Models.ViewModels;
using InAndOut.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class MovieController : Controller
    {
        private IDbService<TblLanguage> _language;
        private IDbService<TblFilm> _film;
        private IDbService<TblGenre> _genre;
        private IActorsService _actors;

        public MovieController(IDbService<TblFilm> film,
            IDbService<TblLanguage> language,
            IDbService<TblGenre> genre,
            IActorsService actors)
        {
            _language = language;
            _film = film;
            _genre = genre;
            _actors = actors;
        }
        public IActionResult Index(int id)
        {
            var film = _film.Get(id);
            var languages = _language.getList().Where(item => item.FilmId == film.FilmId);
            var genres = _genre.getList().Where(item => item.FilmId == film.FilmId);
            var actors = _actors.getlist(id) ;
            ViewBag.Film = film;
            ViewBag.Language = languages;
            ViewBag.Genres = genres;
            ViewBag.Actors = actors;
            return View();
        }
    }
}
