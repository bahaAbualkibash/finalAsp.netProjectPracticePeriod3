using InAndOut.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models.Repository
{
    public interface IData<T> where T : class
    {
         public DbSet<T> GetList();
        public void Update(T item);
        public void Delete(T item);
        public void Insert(T item);



    }
}
