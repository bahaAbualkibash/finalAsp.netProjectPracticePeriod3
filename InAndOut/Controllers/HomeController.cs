using AutoMapper;
using InAndOut.Database;
using InAndOut.Models;
using InAndOut.Models.Repository;
using InAndOut.Models.ViewModels;
using InAndOut.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public  IDbService<TblFilm> _movies { get; }
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, IDbService<TblFilm> movies, IMapper mapper)
        {
            _logger = logger;
            _movies = movies;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var list = _movies.getList();
            var listmovies = _mapper.Map<List<ListMoviesViewModel>>(list);
            return View(listmovies);
        }
       
        public IActionResult MovieDetails(int id)
        {
            var film = _movies.Get(id);
            return View(film);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
