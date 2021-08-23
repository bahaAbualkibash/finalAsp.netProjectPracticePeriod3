using InAndOut.Database;
using InAndOut.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Services
{
    public class LanguageService : IDbService<TblLanguage>
    {
        private readonly IData<TblLanguage> _data;
        public LanguageService(IData<TblLanguage> data)
        {
            _data = data;

        }

        public TblLanguage Search(int id)
        {
            return getList().Where(item => item.LanguageId == id).SingleOrDefault();
        }
        public void Delete(int id)
        {
            _data.Delete(Search(id));
        }

        public TblLanguage Get(int id)
        {
            return Search(id);

        }

        public List<TblLanguage> getList()
        {
            return _data.GetList().ToList();
        }

        public void Insert(TblLanguage item)
        {
            _data.Insert(item);
        }

        public void Update(int id)
        {
            _data.Update(Search(id));
        }
    }
}
