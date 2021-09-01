using InAndOut.Database;
using InAndOut.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Services
{
    public class GenreMovieService : IJunctionService<TblGenreMovies,TblGenre>
    {
        private IData<TblGenreMovies> _data;
        private IData<TblGenre> _genre;

        public GenreMovieService(IData<TblGenreMovies> data, IData<TblGenre> genre)
        {
            _data = data;
            _genre = genre;
        }
        public void Delete(TblGenreMovies item)
        {
            _data.Delete(item);
        }

        public TblGenreMovies Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TblGenre> getAlllist()
        {
            var list = _genre.GetList().ToList();
            return list;
        }

        public List<TblGenreMovies> getlist(int id)
        {
            var list = _data.GetList()
                       .Where(i => i.FilmId == id)
                       .Include(item => item.Genre).ToList();

            return list;

        }

        public void Insert(TblGenreMovies item)
        {

        }
        public TblGenreMovies Search(int FilmId, int GenreId, int oldGenreId)
        {
            return getlist(FilmId).Where(item => item.GenreId == oldGenreId).FirstOrDefault();
        }

        public void Update(int FilmId, int GenreId, int oldGenreId)
        {
            var genre = Search(FilmId, GenreId, oldGenreId);

            if (genre != null)
            {
                genre.GenreId = GenreId;
                genre.FilmId = FilmId;
                _data.Update(genre);

            }
        }
    }
}
