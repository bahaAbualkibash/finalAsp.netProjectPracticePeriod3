using InAndOut.Database;
using InAndOut.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Services
{
    public class GenreService : IDbService<TblGenre>
    {
        private readonly IData<TblGenre> _data;
        public GenreService(IData<TblGenre> data)
        {
            _data = data;

        }

        public TblGenre Search(int id)
        {
            return getList().Where(item => item.GenreId == id).SingleOrDefault();
        }
        public void Delete(int id)
        {
            _data.Delete(Search(id));
        }

        public TblGenre Get(int id)
        {
            return Search(id);

        }

        public List<TblGenre> getList()
        {
            return _data.GetList().ToList();
        }

        public void Insert(TblGenre item)
        {
            _data.Insert(item);
        }

        public void Update(int id)
        {
            _data.Update(Search(id));
        }
    }
}
