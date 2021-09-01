using InAndOut.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Services
{
   public  interface IDbService<T> 
    {
        public List<T> getList();
        public T Get(int id);
        public T Search(int id);
        public void Delete(int id);
        public void Update(T item);
        public void Insert(T item);
    }
}
