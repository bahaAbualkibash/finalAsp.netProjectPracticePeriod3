using InAndOut.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Services
{
    public interface IJunctionService<T,V>
    {

        public List<T> getlist(int id);
        public List<V> getAlllist();
        public void Update(int FilmId,int itemId,int oldItemId);

    }
}
