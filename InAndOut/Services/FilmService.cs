using InAndOut.Database;
using InAndOut.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Services
{
    public class FilmService : IDbService<TblFilm>
    {
        private readonly IData<TblFilm> _data;
        public FilmService(IData<TblFilm> data)
        {
            _data = data;

        }
        
        public TblFilm Search(int id)
        {
            return getList().Where(item => item.FilmId == id).SingleOrDefault();
        }
        public void Delete(int id)
        {
            _data.Delete(Search(id));
        }

        public TblFilm Get(int id)
        {
            return  Search(id);
            
        }

        public List<TblFilm> getList()
        {
            return _data.GetList().ToList();
        }

        public void Insert(TblFilm item)
        {
            _data.Insert(item);
        }

        public void Update(TblFilm film)
        {
            _data.Update(film);
        }
        
    }
}
