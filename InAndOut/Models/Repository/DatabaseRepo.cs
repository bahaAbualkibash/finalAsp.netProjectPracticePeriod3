using InAndOut.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models.Repository
{
    public class DatabaseRepo<T> : IData<T> where T : class
    {
        private readonly MoviesContext _context;
        private DbSet<T> entities;

        public DatabaseRepo(MoviesContext context)
        {
            _context = context;
            entities = _context.Set<T>();
            
        }
        public void Delete(T item)
        {
            entities.Remove(item);
            _context.SaveChanges();
        }

    

        public DbSet<T> GetList()
        {
            return entities;
        }

   
        public async void Insert(T item)
        {
            await entities.AddAsync(item);
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            entities.Update(item);
            _context.SaveChanges();
        }
    }
}
