using AutoMapper;
using InAndOut.Database;
using InAndOut.Models;
using InAndOut.Models.Repository;
using InAndOut.Models.ViewModels;
using InAndOut.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using InAndOut.Models.api;
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

        public  IActionResult Index()
        {
            var list = _movies.getList();
            var listmovies = _mapper.Map<List<ListMoviesViewModel>>(list);
            /*
            foreach (var movie in list)
            {
                var movieName = movie.FilmName;
                var movieYear = Convert.ToDateTime(movie.FilmReleaseDate).Year;
               
                var omdbapi = "https://www.googleapis.com/youtube/v3/search?key=&part=snippet&q=" + movieName +" "+ movieYear + " trailer&type=video&maxResults=1";
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(omdbapi))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                         MovieApi.Rootobject movieFromApi = JsonConvert.DeserializeObject<MovieApi.Rootobject>(apiResponse);
                          movie.FilmImage = movieFromApi.Poster;
                          _movies.Update(movie);
                        TrailerApi.Rootobject trailerVideoApi = JsonConvert.DeserializeObject<TrailerApi.Rootobject>(apiResponse);
                        movie.FilmTrailer = trailerVideoApi.items[0].id.videoId;
                        _movies.Update(movie);

                    }
                }
            }
            */
            
            return View(listmovies);
        }
       
        public IActionResult MovieDetails(int id)
        {
            var film = _movies.Get(id);
            return View(film);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Remove(int id)
        {
            var film = _movies.Get(id);
            return View(film);
        }

        [HttpPost]
        [Authorize]
        [Authorize(Roles = "Admin")]

        public IActionResult Remove(TblFilm film)
        { 
            _movies.Delete(film.FilmId);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        [Authorize(Roles = "Admin")]

        public IActionResult Edit(int id)
        {

            return RedirectToAction("Edit", "Movie", new { ID=id });
        }

        [HttpPost]
        [Authorize]
        [Authorize(Roles = "Admin")]

        public IActionResult Edit(TblFilm film)
        {
            _movies.Update(film);
            return RedirectToAction("Index","Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
