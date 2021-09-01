using AutoMapper;
using InAndOut.Database;
using InAndOut.Models.api;
using InAndOut.Models.Repository;
using InAndOut.Models.ViewModels;
using InAndOut.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class MovieController : Controller
    {
        private IDbService<TblFilm> _film;
        private IJunctionService<TblGenreMovies, TblGenre> _genre;
        private IJunctionService<TblActorsMovie,TblActor> _actors;
        private IJunctionService<TblLanguagesMovies, TblLanguage> _language;

        private readonly IMapper _mapper;
        private readonly IDbService<TblActor> _allActors;

        public MovieController(IDbService<TblFilm> film,
            IJunctionService<TblLanguagesMovies, TblLanguage> language,
            IJunctionService<TblGenreMovies,TblGenre> genre,
            IJunctionService<TblActorsMovie, TblActor> actors,
            IMapper mapper)
        {
            _language = language;
            _film = film;
            _genre = genre;
            _actors = actors;
            _mapper = mapper;
        }
        public IActionResult Index(int id)
        {
            if(id == 0)
            {
                return RedirectToAction("Index","Home");
            }
            var film = _film.Get(id);
            var languages = _language.getlist(id);
            var genres = _genre.getlist(film.FilmId);
            var actors = _actors.getlist(id) ;
            ViewBag.Film = film;
            ViewBag.Language = languages;
            ViewBag.Genres = genres;
            ViewBag.Actors = actors;
            return View();
        }

        [HttpGet]
        [Authorize]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int ID)
        {
            var film = _film.Get(ID);
            film.FilmPrice = decimal.Round(film.FilmPrice,2, MidpointRounding.AwayFromZero);
            var languages = _language.getlist(ID);
            var genres = _genre.getlist(film.FilmId);
            var actors = _actors.getlist(ID);
            var movieVW = _mapper.Map<EditMovieViewModel>(film);
            movieVW.Languages = languages;
            movieVW.Genres = genres;
            movieVW.Actors = actors;
            var allLang = _language.getAlllist();
            var allGenre = _genre.getAlllist();

            //var actor = _actors.getlist(ID);
            //var movievw = new EdItMovieViewModel() {
            //    Movie = film,
            //    actors = actor,
            //    genre = genres,
            //    MovieLanguages = languages
            //};
            var allactors = _actors.getAlllist();

            ViewBag.AllLanguages = allLang;
            ViewBag.AllActors = allactors;
            ViewBag.AllGenres = allGenre;
            return View(movieVW);


        }

        [HttpPost]
        [Authorize]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(EditMovieViewModel model)
        {

            if (ModelState.IsValid)
            {
                var movie = _film.Get(model.FilmId);
                movie.FilmName = model.FilmName;
                movie.FilmPrice = model.FilmPrice;
                movie.FilmSynopsis = model.FilmSynopsis;
                movie.FilmRunTimeMinutes = model.FilmRunTimeMinutes;
                movie.FilmReleaseDate = model.FilmReleaseDate;
                _film.Update(movie);
                var oldactors = _actors.getlist(model.FilmId);
                for (var i=0;i<oldactors.Count;i++ )
                {
                    if(model.Actors[i].ActorId != oldactors[i].ActorId)
                    { 
                            _actors.Update(model.FilmId, (int)model.Actors[i].ActorId, (int) oldactors[i].ActorId);
                    }
                }
                var oldGenre = _genre.getlist(model.FilmId);
                for (var i = 0; i < oldGenre.Count; i++)
                {
                    if (model.Genres[i].GenreId != oldGenre[i].GenreId)
                    {
                        _genre.Update(model.FilmId, (int)model.Genres[i].GenreId, (int)oldGenre[i].GenreId);
                    }
                }
                var oldLanguages = _language.getlist(model.FilmId);
                for (var i = 0; i < oldLanguages.Count; i++)
                {
                    if (model.Languages[i].LanguageId != oldLanguages[i].LanguageId)
                    {
                        _language.Update(model.FilmId, (int)model.Languages[i].LanguageId, oldLanguages[i].LanguageId);
                    }
                }
            }
            return RedirectToAction("Index","Home"); 
        }

        [HttpGet]
        [Authorize]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateMovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                var OMDBApi = "http://www.omdbapi.com/?apikey=3e74c857&s=" + model.MovieName + "&type=movie&y=" + model.MovieYearOfRelease;
                using(var httpClient = new HttpClient())
                {
                    using(var response = await httpClient.GetAsync(OMDBApi))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        CreateMovieApi.Rootobject obj = JsonConvert.DeserializeObject<CreateMovieApi.Rootobject>(apiResponse);
                        ViewBag.Result = obj.Search;
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Submit(string id)
        {
                var themoviedb = @$"https://api.themoviedb.org/3/movie/{id}?api_key=2bf25c71b9c2f26659f6365cf3fd977e&append_to_response=videos";
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(themoviedb))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        MovieDetails.Rootobject obj = JsonConvert.DeserializeObject<MovieDetails.Rootobject>(apiResponse);
                    TblFilm film = new TblFilm();
                    film.FilmName = obj.title;
                    film.FilmBoxOfficeDollars = obj.revenue;
                    film.FilmBudgetDollars = obj.revenue;
                    film.FilmReleaseDate = Convert.ToDateTime(obj.release_date);
                    film.FilmRunTimeMinutes = obj.runtime;
                    film.FilmSynopsis = obj.overview;
                    foreach(var genre in obj.genres)
                    {
                        // check if genre already exsist
                        //if does not exsist add it do genre table 
                    }
                    // to do send to db
                }
            }
             themoviedb = @$"https://api.themoviedb.org/3/movie/{id}/credits?api_key=2bf25c71b9c2f26659f6365cf3fd977e&language=en-U";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(themoviedb))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    CreditDetials.Rootobject obj = JsonConvert.DeserializeObject<CreditDetials.Rootobject>(apiResponse);
                    // to do add actors to film
                }
            }
            themoviedb = @$"https://api.themoviedb.org/3/movie/{id}/videos?api_key=2bf25c71b9c2f26659f6365cf3fd977e&language=en-US";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(themoviedb))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    VideosMovie.Rootobject obj = JsonConvert.DeserializeObject<VideosMovie.Rootobject>(apiResponse);
                    // add trailer to film
                }
            }

            return View();
        }
    }
}
