using InAndOut.Database;
using InAndOut.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Services
{
    public class LanguageMovieService : IJunctionService<TblLanguagesMovies,TblLanguage>
    {
        private IData<TblLanguagesMovies> _data;
        private IData<TblLanguage> _language;

        public LanguageMovieService(IData<TblLanguagesMovies> data, IData<TblLanguage> language)
        {
            _data = data;
            _language = language;
        }
        public void Delete(TblLanguagesMovies item)
        {
            _data.Delete(item);
        }

        public TblLanguagesMovies Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TblLanguage> getAlllist()
        {
            var list = _language.GetList().ToList();
            return list;
        }

        public List<TblLanguagesMovies> getlist(int id)
        {
            var list = _data.GetList()
                       .Where(i => i.FilmId == id)
                       .Include(item => item.Language).ToList();

            return list;

        }

        public void Insert(TblLanguagesMovies item)
        {

        }
        public TblLanguagesMovies Search(int FilmId, int LanguageId, int oldLanguageId)
        {
            return getlist(FilmId).Where(item => item.LanguageId == oldLanguageId).FirstOrDefault();
        }

        public void Update(int FilmId, int LanguageId, int oldLanguageId)
        {
            var language = Search(FilmId, LanguageId, oldLanguageId);

            if (language != null)
            {
                language.LanguageId = LanguageId;
                language.FilmId = FilmId;
                _data.Update(language);

            }
        }
    }
}
