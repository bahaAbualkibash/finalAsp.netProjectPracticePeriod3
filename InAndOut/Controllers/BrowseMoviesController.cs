using AutoMapper;
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
    public class BrowseMoviesController : Controller
    {
        private readonly IDbService<TblGenre> _genre;
        private readonly IDbService<TblLanguage> _language;
        private readonly IDbService<TblFilm> _film;

        public BrowseMoviesController(
            IDbService<TblGenre> genre, 
            IDbService<TblLanguage> language,
            IDbService<TblFilm> film) 
        {
            _genre = genre;
            _film = film;
            _language = language;
        }
        public IActionResult Index()
        {
            var browseMoviesDetials = new BrowseMoviesDetialsViewModel() {
                Films = _film.getList(),
                Generes = _genre.getList(),
                Laguages = _language.getList()
            };
            
            return View(browseMoviesDetials);
        }
    }
}
